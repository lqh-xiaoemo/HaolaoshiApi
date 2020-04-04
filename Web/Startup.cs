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
            // ����Controllerȫ����Autofac����Ĭ������£�Controller�Ĳ�������������������Controller�Ĵ�������AspNetCore���ʵ�ֵġ�Ҫͨ����������Controller����Ҫ��Startup������һ�£�
           services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());
            //��ȡ���֤
            //services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
            //services.AddSingleton<IPrincipalAccessor, PrincipalAccessor>();
            //services.AddSingleton<IClaimsAccessor, ClaimsAccessor>();

            //ע��������
            services.AddCors(corsOptions =>
            {
                //��ӿ������
                corsOptions.AddPolicy("any", buidler =>
                {
                    //�������з�����������������ͷ���������е����󷽷�
                    // Console.WriteLine(Configuration.GetValue<string>("CorsOrigins").Split(',').Length);
                    buidler.WithOrigins(Configuration.GetValue<string>("CorsOrigins").Split(',')).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    //buidler.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                });
            });
            services.AddControllers();
            //ע�������Ķ���
            services.AddDbContext<MyDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlServer"));
            //options.EnableSensitiveDataLogging();
        });
            //�� Swagger ��������ӵ� Startup.ConfigureServices �����еķ��񼯺��У� Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerService();

            //��appsettings.json�е�JwtSettings�����ļ���ȡ��JwtSettings�У����Ǹ������ط��õ�
            services.Configure<JwtConfig>(Configuration.GetSection("JwtConfig"));

            //���ڳ�ʼ����ʱ�����Ǿ���Ҫ�ã�����ʹ��Bind�ķ�ʽ��ȡ����
            //�����ð󶨵�JwtConfigʵ����
            var jwtConfig = new JwtConfig();
            Configuration.Bind("JwtConfig", jwtConfig);
            //��֤��Ȩ
            services.ConfigureJwt(jwtConfig);

            //��ʼ��redis
            services.InitRedisConnect(Configuration);
            //RedisClient.redisClient.InitConnect(Configuration);

        }
        //����autofac����ע��
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
            //�� Startup.Configure �����У������м��Ϊ���ɵ� JSON �ĵ��� Swagger UI �ṩ����
            app.UseSwaggerService();
            app.UseCors("any");//������������
            app.UseOptions(); // ������������  Ԥ���                           
            app.UseAuthentication();  //��֤                    
            app.UseStaticFiles();//���ڷ���wwwroot�µ��ļ� 

            app.UseHttpsRedirection();

            app.UseRouting();
     
            app.UseAuthorization();

            app.UseMiddleware<JwtAuthorizationFilter>();  //��Ȩ

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
