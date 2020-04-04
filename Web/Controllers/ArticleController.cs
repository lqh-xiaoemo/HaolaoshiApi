using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;
using Bll;
using Common;
using Web.Extension;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    [Authorize]
    public class ArticleController : MyBaseController
    {
        public ICategoryBll categoryBll { get; set; }
        public ArticleController()
        {
        }
        /// <summary>
        /// 文章、课程所有分类
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        // GET: api/Article/CategoryList
        [HttpGet("category")]
        public Result Category([FromQuery] Dictionary<string, string> where)
        {
            return Result.Success("succeed").SetData(categoryBll.Query(where));
        }
    }
}
