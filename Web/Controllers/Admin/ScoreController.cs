﻿using System;
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
using Web.Controllers;

namespace Web.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ScoreController : MyBaseController
    {
        IScoreBll bll;
        public ScoreController(IScoreBll bll)
        {
            this.bll = bll;
        }
        // GET: api/List/Score
        [HttpGet]
        public Result List([FromQuery] Dictionary<string, string> where)
        {
            //return Result.Success("succeed").SetData(bll.SelectAll(o => true, pageNo, pageSize));
            return Result.Success("succeed").SetData(bll.Query(where));
        }

        // GET: api/Score/Get/5
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            return Result.Success("succeed").SetData(bll.SelectOne(id));
        }
        // POST: api/Score/Add
        [HttpPost]
        public Result Add(Score o)
        {
            return ModelState.IsValid ? (bll.Add(o) ? Result.Success("添加成功") : Result.Error("添加失败")) : Result.Error("添加失败!"+ModelState.GetAllErrMsgStr(";"));;
        }

        // Post: api/Score/Update
        [HttpPost]
        public Result Update(Score o)
        {
            return ModelState.IsValid ? (bll.Update(o) ? Result.Success("修改成功").SetData(o) : Result.Error("修改失败")) : Result.Error("修改失败!" + ModelState.GetAllErrMsgStr(";")); ;
        }

        // Get: api/Score/Delet/5
        [HttpGet("{id}")]
        public Result Delete(int id)
        {
            return bll.Delete(id) ? Result.Success("删除成功") : Result.Error("删除失败");
        }
    }
}
