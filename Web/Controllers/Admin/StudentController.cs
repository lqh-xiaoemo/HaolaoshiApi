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
using Common.Util;
using Web.Controllers;

namespace Web.Admin.Controllers
{
    [Route("api/admin/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class StudentController : MyBaseController
    {
        public IClasssBll classsBll { get; set; }
        IStudentBll bll;
        private readonly IWebHostEnvironment webHostEnvironment;
        public StudentController(IStudentBll bll, IWebHostEnvironment hostingEnvironment)
        {
            this.bll = bll;
            this.webHostEnvironment = hostingEnvironment;
        }
        // GET: api/List/Student
        [HttpGet]
        public Result List([FromQuery] Dictionary<string, string> where)
        {
            //return Result.Success("succeed").SetData(bll.SelectAll(o => true, pageNo, pageSize));
            return Result.Success("succeed").SetData(bll.Query(where));
        }

        // GET: api/Student/Get/5
        [HttpGet("{id}")]
        public Result Get(int id)
        {
            return Result.Success("succeed").SetData(bll.SelectOne(id));
        }
        // POST: api/Student/Add
        [HttpPost]
        public Result Add(Student o)
        {
            return ModelState.IsValid ? (bll.Add(o) ? Result.Success("添加成功") : Result.Error("添加失败")) : Result.Error("添加失败!" + ModelState.GetAllErrMsgStr(";")); ;
        }

        // Post: api/Student/Update
        [HttpPost]
        public Result Update(Student o)
        {
            return ModelState.IsValid ? (bll.Update(o) ? Result.Success("修改成功").SetData(o) : Result.Error("修改失败")) : Result.Error("修改失败!" + ModelState.GetAllErrMsgStr(";")); ;
        }

        // Get: api/Student/Delet/5
        [HttpGet("{id}")]
        public Result Delete(int id)
        {
            return bll.Delete(id) ? Result.Success("删除成功") : Result.Error("删除失败");
        }
        // Get: api/Student/Delet/5
        //[HttpGet()]
        //public Result Import()
        //{
        //    string filename = hostingEnvironment.WebRootPath + "/计应4班学籍详细信息.xlsx";
        //    return  Result.Success("导入成功").SetData(OfficeHelper.ReadExcelToDataTable(filename)) ;
        //}
        private string[] imgExt = { ".xlsx", ".xls" };
        private int imgSizeLimit = 5000 * 1024;

        [HttpPost()]
        //public async Task<Result> Import(IFormFile file,[FromBody]int classsId)
        public Result Import([FromForm] IFormCollection formCollection)
        {
            var classsId = Convert.ToInt32(formCollection["classsId"]);
            FormFileCollection fileCollection = (FormFileCollection)formCollection.Files;
            foreach (IFormFile file in fileCollection)
            {
                var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(ext) || !imgExt.Contains(ext))
                {
                    return Result.Error("上传失败,请选择xlsx类型文件");
                }
                if (file.Length > 0)
                {
                    if (file.Length > imgSizeLimit)
                    {
                        var size = imgSizeLimit / 1024;
                        return Result.Error($"上传失败,文件超过大小{size}KB");
                    }
                    string filePath = "/temp/" + file.FileName;
                    DataTable dt = OfficeHelper.ReadExcelToDataTable(file.OpenReadStream());
                    foreach (DataRow row in dt.Rows)
                    {
                        Student s = new Student();
                        s.Username = row["学号"].ToString();
                        s.Role = "student";
                        s.Pswd = row["学号"].ToString();
                        s.Sn = row["学号"].ToString();
                        s.Gender = Gender.man.Parse<Gender>(row["性别"].ToString());
                        s.Realname = row["姓名"].ToString();
                        s.Nation = row["民族"].ToString();
                        s.IDCard = row["身份证号"].ToString();
                        s.Address = row["通信地址"].ToString();
                        s.Email = row["电子邮箱"].ToString();
                        s.Zip = row["邮编"].ToString();
                        s.Photo = "/upload/student/" + classsId + "/" + s.Realname + ".jpg";
                        s.Tel = row["联系电话"].ToString();
                        s.Father = row["家长姓名"].ToString();
                        s.FathertTel = row["家长联系电话"].ToString();
                        s.ClasssId = classsId;
                        this.bll.Add(s);
                    }
                    //using (var stream = System.IO.File.Create(webHostEnvironment.WebRootPath + filePath))
                    //{

                    //    //await file.CopyToAsync(stream);
                    //}
                    return Result.Success("导入成功");
                }
                else
                {
                    return Result.Success("导入失败,空文件");
                }
            }
            return Result.Success("导入失败,请上传文件");
        }

    }
}
