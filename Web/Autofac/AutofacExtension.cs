using Autofac;
using Autofac.Extensions.DependencyInjection;
using Bll;
using Bll.Impl;
using DAL;
using DAL.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Web.Autofac
{
    /// <summary> 
    ///  //配置autofac依赖注入
    ///  https://blog.csdn.net/yikeshu19900128/article/details/42741779
    /// </summary>
    public static class AutofacExtension
    {
        private static readonly List<string> _Assemblies = new List<string>()
        {
            "Bll","DAL","Web"
        };
        public static void ConfigureAutofac(this ContainerBuilder builder)
        {
            var assemblys = _Assemblies.Select(x => Assembly.Load(x)).ToList();
            List<Type> allTypes = new List<Type>();
            assemblys.ForEach(aAssembly =>
            {
                allTypes.AddRange(aAssembly.GetTypes());
            });

            // 通过Autofac自动完成依赖注入
            builder.RegisterTypes(allTypes.ToArray())
                .AsImplementedInterfaces()
                .PropertiesAutowired()
                .InstancePerDependency();

            builder.RegisterType<HttpContextAccessor>().AsImplementedInterfaces();
            //// Assembly web = Assembly.Load("Web");
            // //业务逻辑层所在程序集命名空间
            // Assembly service = Assembly.Load("Bll");
            // //接口层所在程序集命名空间
            // Assembly repository = Assembly.Load("DAL");
            // //自动注入
            // builder.RegisterAssemblyTypes(service)
            //     .Where(t => t.Name.EndsWith("Bll"))
            //     .AsImplementedInterfaces();

            // builder.RegisterAssemblyTypes(repository)
            //    .Where(t => t.Name.EndsWith("DAL"))
            //    .AsImplementedInterfaces();

            //  builder.RegisterAssemblyTypes(web)
            //   .Where(t => t.Name.EndsWith("Impl"))
            //  .AsImplementedInterfaces();

            ////对泛型类进行注册 注册仓储，所有IRepository接口到Repository的映射
            //builder.RegisterGeneric(typeof(BaseBll<>))
            //    //InstancePerDependency：默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
            //    .As(typeof(IBaseBll<>)).InstancePerDependency();

            //builder.RegisterGeneric(typeof(BaseDAL<>))
            ////InstancePerDependency：默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
            //.As(typeof(IBaseDAL<>)).InstancePerDependency();


            //// 注册了当前程序集内的所有的类
            //builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired(); ;

            //https://www.cnblogs.com/diwu0510/p/11562248.html
            //如果需要在Controller中使用属性注入，需要在ConfigureContainer中添加如下代码
            var controllerBaseType = typeof(ControllerBase);
            builder.RegisterAssemblyTypes(typeof(Program).Assembly)
                .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
                .PropertiesAutowired(); 
        }

        public static IHostBuilder UseAutofacServiceProviderFactory(this IHostBuilder builder)
        {
            //将默认ServiceProviderFactory指定为AutofacServiceProviderFactory
            return builder.UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }
    }
}
