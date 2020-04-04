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
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Web.Controllers;

namespace Web.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    public class ImageController : MyBaseController
    {
        IImageBll bll;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ImageController(IImageBll bll, IWebHostEnvironment webHostEnvironment)
        {
            this.bll = bll;
            this.webHostEnvironment = webHostEnvironment;
        }
        // GET: api/List/Images
        [HttpGet]
        public Result List([FromQuery] Dictionary<string, string> where)
        {
            //return Result.Success("succeed").SetData(bll.SelectAll(o => true, pageNo, pageSize));
            return Result.Success("succeed").SetData(bll.Query(where));
        }

        // GET: api/Images/Get/5
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            return Result.Success("succeed").SetData(bll.SelectOne(id));
        }
        // POST: api/Images/Add
        [HttpPost]
        public Result Add(Image o)
        {
            return ModelState.IsValid ? (bll.Add(o) ? Result.Success("添加成功") : Result.Error("添加失败")) : Result.Error("添加失败!" + ModelState.GetAllErrMsgStr(";")); ;
        }

        // Post: api/Images/Update
        [HttpPost]
        public Result Update(Image o)
        {
            return ModelState.IsValid ? (bll.Update(o) ? Result.Success("修改成功").SetData(o) : Result.Error("修改失败")) : Result.Error("修改失败!" + ModelState.GetAllErrMsgStr(";")); ;
        }

        // Get: api/Images/Delet/5
        [HttpGet("{id}")]
        public Result Delete(int id)
        { 
            var obj = bll.SelectOne(id);
            string filePath = webHostEnvironment.WebRootPath + obj.Path;
            System.IO.File.Delete(filePath);
            return bll.Delete(id) ? Result.Success("删除成功") : Result.Error("删除失败");
        }
       
        //[HttpPost]
        //public async Task<Result> Upload(List<IFormFile> files)
        //{
        //    long size = files.Sum(f => f.Length);

        //    foreach (var formFile in files)
        //    {
        //        if (formFile.Length > 0)
        //        {
        //            var filePath = Path.GetTempFileName();
        //            HttpContext.ser
        //            var path = hServer.MapPath(path);
        //            using (var stream = System.IO.File.Create(filePath))
        //            {
        //                await formFile.CopyToAsync(stream);
        //            }
        //        }
        //    }

        //    // Process uploaded files
        //    // Don't rely on or trust the FileName property without validation.

        //    return Ok(new { count = files.Count, size, filePath });
        //}
    }
}
