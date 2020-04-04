﻿using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Common.Util
{
    /// <summary>
    /// 反射类
    /// </summary>
    public class Reflect
    {
        /// <summary>
        /// 将字符串的值转换为T对应属性property的值
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="property"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public static object ConvertPropertyType<T>(string property, string val)
        {
            Type classType = typeof(T);//类的类型
            PropertyInfo pro = classType.GetProperty(property);
            if (pro == null) return null;
            Type proType = pro.PropertyType;//属性的类型
            bool isNullable = false;
            //泛型Nullable判断，取其中的类型
            if (proType.IsGenericType)
            {
                proType = proType.GetGenericArguments()[0];
                isNullable = true;
            }
            if (string.IsNullOrEmpty(val)) return proType.IsValueType && !isNullable ? Activator.CreateInstance(proType) : null; ;//返回类型的默认值
            //string直接返回转换
            if (proType.Name.ToLower() == "string")
            {
                return val;
            }
            //反射获取TryParse方法
            var TryParse = proType.GetMethod("TryParse", BindingFlags.Public | BindingFlags.Static, Type.DefaultBinder,
                                            new Type[] { typeof(string), proType.MakeByRefType() },
                                            new ParameterModifier[] { new ParameterModifier(2) });
            var parameters = new object[] { val, Activator.CreateInstance(proType) };
            bool success = (bool)TryParse.Invoke(null, parameters);
            //成功返回转换后的值，否则返回类型的默认值
            if (success)
            {
                return parameters[1];
            }
            return proType.IsValueType ? Activator.CreateInstance(proType) : null;
        }
        static void Main(string[] args)
        {
           // Console.WriteLine(ConvertPropertyType<A>("Name", "33"));
        }
    }
}
