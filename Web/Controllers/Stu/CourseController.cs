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

namespace Web.Controllers.Stu
{
    [Route("api/stu/")]
    [ApiController]
    [Authorize]
    public class CourseController : MyBaseController
    {
        ICourseBll bll;
        public IChapterBll chapterBll { get; set; }
        public CourseController(ICourseBll bll)
        {
            this.bll = bll;
        }
        [HttpGet("course/list")]
        public Result List([FromQuery] Dictionary<string, string> where)
        {
            return Result.Success("succeed").SetData(bll.Query(where));
        }

        // GET: api/Course/Get/5
        [HttpGet("course/{id}")]
        public Result Get(int id)
        {
            return Result.Success("succeed").SetData(bll.SelectOne(id));
        }
        [HttpGet("chapter/list/{courseId}")]
        public Result ChapterList(int courseId)
        {
            return Result.Success("succeed").SetData(chapterBll.SelectAll(o=>o.CourseId== courseId && o.ParentId==null));
        }

        // GET: api/Course/Get/5
        [HttpGet("chapter/{id}")]
        public Result ChapterGet(int id)
        {
            return Result.Success("succeed").SetData(chapterBll.SelectOne(id));
        }
    }
}
