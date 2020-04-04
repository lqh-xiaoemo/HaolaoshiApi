using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;
using Web.Autofac;
using Web.Extension;
using Web.Jwt;
using Web.Redis;
using Web.Security;
using Web.Swagger;
using Web.Util;

namespace Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 配置Controller全部由Autofac创建默认情况下，Controller的参数会由容器创建，但Controller的创建是有AspNetCore框架实现的。要通过容器创建Controller，需要在Startup中配置一下：
           services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            //获取身份证
            //services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
            //services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
            //services.AddSingleton<IClaimsAccessor, ClaimsAccessor>();

            //注册跨域服务
            services.AddCors(corsOptions =>
            {
                //添加跨域策略
                corsOptions.AddPolicy("any", buidler =>
                {
                    //允许所有访问域、允许所有请求头、允许所有的请求方法
                    // Console.WriteLine(Configuration.GetValue<string>("CorsOrigins").Split(',').Length);
                    buidler.WithOrigins(Configuration.GetValue<string>("CorsOrigins").Split(',')).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    //buidler.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddControllers();
            //注册上下文对象
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            //options.EnableSensitiveDataLogging();
        });
            //将 Swagger 生成器添加到 Startup.ConfigureServices 方法中的服务集合中： Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerService();

            //将appsettings.json中的JwtSettings部分文件读取到JwtSettings中，这是给其他地方用的
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            //由于初始化的时候我们就需要用，所以使用Bind的方式读取配置
            //将配置绑定到JwtConfig实例中
            var jwtConfig = new JwtConfig();
            Configuration.Bind("JwtConfig", jwtConfig);
            //认证授权
            services.ConfigureJwt(jwtConfig);

            //初始化redis
            services.InitRedisConnect(Configuration);
            //RedisClient.redisClient.InitConnect(Configuration);

        }
        //配置autofac依赖注入
        public void ConfigureContainer(ContainerBuilder builder)
        {
    
            builder.ConfigureAutofac();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // using Microsoft.AspNetCore.HttpOverrides;
            //https://docs.microsoft.com/zh-cn/aspnet/core/host-and-deploy/linux-nginx?view=aspnetcore-2.2
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});
            //在 Startup.Configure 方法中，启用中间件为生成的 JSON 文档和 Swagger UI 提供服务：
            app.UseSwaggerService();
            app.UseCors("any");//启动跨域请求
            app.UseOptions(); // 启动跨域请求  预检测                           
            app.UseAuthentication();  //认证                    
            app.UseStaticFiles();//用于访问wwwroot下的文件 

            app.UseHttpsRedirection();

            app.UseRouting();
     
            app.UseAuthorization();

            app.UseMiddleware<JwtAuthorizationFilter>();  //授权

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
