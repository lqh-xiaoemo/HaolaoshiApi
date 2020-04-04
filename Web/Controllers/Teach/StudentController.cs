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
using Web.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using System.Data;
using Web.Redis;
using StackExchange.Redis;
using System.Collections;
using Web.Controllers;

namespace Web.Teach.Controllers
{
    [Route("api/teach/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StudentController : MyBaseController
    {
        public IClasssBll classsBll { get; set; }
        public IStudentBll bll { get; set; }
        private readonly IWebHostEnvironment webHostEnvironment;
        public StudentController(IWebHostEnvironment hostingEnvironment)
        {
            this.webHostEnvironment = hostingEnvironment;
        }
        /// <summary>
        /// 已签到学生列表
        /// </summary>
        /// <param name="classid"></param>
        /// <returns></returns>
        [HttpGet()]
        public Result ClockList(string classid)
        {
            //缓存学生信息
            RedisHelper rd = RedisHelper.Instance();
            //所有待签到的学生集合
            rd.SetSysCustomKey("clock_stu_all");
            //获取所有用户名集合
            List<string> keys = rd.HashKeys<string>(classid.ToString());
            rd.SetSysCustomKey("clock_stu");//切换到已签到的学生集合
            //签到列表
            var ss = new ArrayList();
            List<ElementScore<string>> clockss = rd.SortedSetRangeByRankWithScores<string>(classid.ToString());//升序
            //切换到所有人列表                                                                                                  //所有待签到的学生集合
            rd.SetSysCustomKey("clock_stu_all");
            foreach (ElementScore<string> c in clockss) {
                if(c.Element == "#0#")  continue;
                ss.Add(new { username =c.Element, realname = rd.HashGet<string>(classid, c.Element) ,time= DateTime.FromOADate(c.Score).ToString("HH:mm:ss") });
            }
            return Result.Success("查询成功").SetData(new { total = keys.Count, items = ss });//total总人数
        }
        /// <summary>
        /// 查询未签到列表
        /// </summary>
        /// <param name="classid">班级id</param>
        /// <returns>new { total= 总人数,items=未签到列表对象{username,realname }}</returns>
        [HttpGet()]
        public Result UnClockList(string classid)
        {
            //缓存学生信息
            RedisHelper rd = RedisHelper.Instance();
            //所有待签到的学生集合
            rd.SetSysCustomKey("clock_stu_all");
            //获取所有用户名集合
            List<string> keys = rd.HashKeys<string>(classid.ToString());
            rd.SetSysCustomKey("clock_stu");//切换到已签到的学生集合
            //未签到列表
            var ss = new ArrayList();
            //循环
            foreach (var k in keys)
            {
                if (!rd.SortedSetContains<string>(classid, k))
                { //如果不包含表示未签到
                    rd.SetSysCustomKey("clock_stu_all");
                    ss.Add(new { username = k, realname = rd.HashGet<string>(classid, k) });
                    rd.SetSysCustomKey("clock_stu");
                }
            }
            return Result.Success("查询成功").SetData(new { total = keys.Count, items = ss });//total总人数
        }
        /// <summary>
        ///  教师发起学生签到
        /// </summary>
        /// <param name="classid">班级id</param>
        /// <param name="answer">签到问题答案</param>
        /// <param name="expire">签到时长</param>
        /// <param name="holdexpire">签到信息保留时间，默认签到时长（默认 60）+120秒，后签到信息自动删除</param>
        /// <returns></returns>
        [HttpPost()]
        public Result Clock(string classid, string answer, int expire = 60, int holdexpire = 120)
        {
            //缓存学生信息
            RedisHelper rd = RedisHelper.Instance();
            rd.SetSysCustomKey("clock_stu_all");//所有待签到的学生集合
            if (!rd.KeyExists(classid.ToString()))
            {
                var stus = bll.SelectAll(o => o.ClasssId == int.Parse(classid));
                foreach (var s in stus)
                {
                    rd.HashSet(classid.ToString(), s.Username, s.Realname);
                }
            }
            //设置签到列表 
            rd.SetSysCustomKey("clock_stu");//已签到的学生集合 
            rd.SortedSetAdd(classid, "#0#",DateTime.Now.ToOADate());//已签到集合默认不然没法设置有效时间
            rd.KeyExpire(classid, TimeSpan.FromSeconds(expire + holdexpire));//设置签到信息保留时间
            rd.StringSet(classid + "expire", expire, TimeSpan.FromSeconds(expire));//签到时长
            rd.StringSet(classid + "answer", answer, TimeSpan.FromSeconds(expire));//签到答案
            return Result.Success("发起签到成功");
        }


    }
}
