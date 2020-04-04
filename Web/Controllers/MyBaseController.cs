using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Bll;
using Common;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Web.Extension;
using Web.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using Web.Util;
using System.Security.Claims;
using Web.Security;

namespace Web.Controllers
{
    /// <summary>
    /// 公共的属性、方法、变量
    /// </summary>
    [Controller]
    public abstract class MyBaseController : ControllerBase
    {
        /// <summary>
        /// 身份信息
        /// </summary>
       
        public MyBaseController()
        {
          
        }      
    }
}