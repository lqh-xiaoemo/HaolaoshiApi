using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Web.Redis;
using Web.Security;

namespace Web.Controllers.Stu
{
    [Route("api/stu/")]
    [ApiController]
    [Authorize]
    public class DefaultController : MyBaseController
    {
        public IClaimsAccessor MyUser { get; set; }
        /// <summary>
        /// 签到打卡
        /// </summary>
        /// <param name="answer"></param>
        /// <returns></returns>
        [HttpPost("clock")]
        [HttpGet("clock/{answer}")]
        public Result Clock(string answer)
        {
            string classid = MyUser.Project;//班级id
            string name = MyUser.Name;
            RedisHelper rd = RedisHelper.Instance();
            rd.SetSysCustomKey("clock_stu");//已签到的学生集合     
            RedisValue expire = rd.StringGet(classid + "expire");//签到时长
            if (expire.IsNullOrEmpty) 
            {
                return Result.Error("打卡结束,或未开始");
            }
            if (!rd.SortedSetContains(classid, name)) 
            {//包含表示打卡过
                var rightanswer = rd.StringGet<string>(classid + "answer");//签到答案
                if (rightanswer != answer)
                {
                    return Result.Error("打卡失败，暗号错误");
                }
                rd.SortedSetAdd<string>(classid, name, DateTime.Now.ToOADate());
                return Result.Success("打卡成功");
            }
            return Result.Error("已打卡");
        }
    }
}