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
using System.Drawing.Imaging;

namespace Web.Controllers
{
    /// <summary>
    /// 好老师。常用的接口
    /// </summary>
    [Route("api/")]
    [ApiController]
    public class DefaultController : MyBaseController
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly JwtConfig jwtConfig;
        public IUserBll userBll { get; set; }//通过属性依赖注入
        public IStudentBll studentBll { get; set; }
        public ITeacherBll teacherBll { get; set; }
        public IImageBll imageBll { get; set; }
        public IClaimsAccessor MyUser { get; set; }
        IConfiguration configuration { get; set; }
        public DefaultController(IWebHostEnvironment webHostEnvironment, IConfiguration configuration, IOptions<JwtConfig> jwtConfig)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.jwtConfig = jwtConfig.Value;
            this.configuration = configuration;
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="o">接收username、password、type三个参数</param>
        /// <returns></returns>
        // POST: api/login
        [HttpPost("login")]
        public Result Login([FromBody] Userinfo o)
        // public Result Login(string username,string password,string type="student")
        {
            string project = "";
            Person obj = null;
            if (o.Type == "teacher")
            {
                obj = teacherBll.Login(o.Username, o.Password);
            }
            else if (o.Type == "student")
            {
                obj = studentBll.Login(o.Username, o.Password);
                if (obj != null) project = ((Student)obj).ClasssId.ToString();
            }
            else
            {
                obj = userBll.Login(o.Username, o.Password);
            }
            if (obj != null)
            {
                var t = new Token() { Uid = obj.Id, Uname = obj.Username, Role = obj.Role, TokenType = TokenType.App, Project = project };
                return Result.Success("登录成功")
                    .SetData(new Userinfo() { Username = obj.Username, Avatar = obj.Photo, Role = obj.Role, Type = o.Type, Realname = obj.Realname, Tel = obj.Tel, Email = obj.Email, Birthday = obj.Birthday, Token = JwtHelper.IssueJWT(t, this.jwtConfig) });
                //return Result.Success("登录成功").SetData(new Userinfo() { Token = "admin" });
            }
            return Result.Error("登录失败").SetData(new Userinfo() { Token = "" });
        }
        // GET: api/getuserinfo
        /// <summary>
        /// 获取登录信息
        /// </summary>
        /// <returns></returns>
        [HttpGet("getuserinfo")]
        [Authorize]
        public Result GetUserinfo()
        {
            var obj = this.userBll.SelectOne(MyUser.Id);
            if (obj != null)
            {
                obj.Pswd = "";
                return Result.Success("获取成功").SetData(obj);
            }
            return Result.Error("获取失败").SetData(new Userinfo() { });
        }

        private string[] imgExt = { ".jpg", ".jpeg", ".png", ".gif" };
        private int imgSizeLimit = 500 * 1024;
        /// <summary>
        /// 图片上传
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        [HttpPost("imgupload")]
        [Authorize]
        public async Task<Result> ImgUpload(IFormFile file)
        {
            var ext = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (string.IsNullOrEmpty(ext) || !imgExt.Contains(ext))
            {
                return Result.Error("上传失败,请选择jpg|jpeg|png|gif类型图片");
            }
            if (file.Length > 0)
            {
                if (file.Length > imgSizeLimit)
                {
                    var size = imgSizeLimit / 1024;
                    return Result.Error($"上传失败,文件超过大小{size}KB");
                }
                Image o = new Image
                {
                    Name = file.FileName
                };
                string filePath = "/upload/" + file.FileName;
                o.Path = filePath;
                using (var stream = System.IO.File.Create(webHostEnvironment.WebRootPath + filePath))
                {
                    await file.CopyToAsync(stream);
                }
                imageBll.Add(o);
                return Result.Success("上传成功").SetData(o);
            }
            else
            {
                return Result.Success("上传失败,空文件");
            }
        }
        /// <summary>
        /// 生成二维码图片
        /// </summary>
        /// <param name="text"></param>
        /// <param name="size">生成二维码图片的像素大小</param>
       // [HttpGet("qrcode/{text}/{size}")]
        [HttpGet("qrcode")]
        public void GetQRCode(string text, int size= 5)
        {
            Response.ContentType = "image/jpeg";
            var bitmap = QRCodeHelper.GetQRCode(text, size);
            MemoryStream ms = new MemoryStream();
            bitmap.Save(ms, ImageFormat.Jpeg);
            Response.Body.WriteAsync(ms.GetBuffer(), 0, Convert.ToInt32(ms.Length));
            Response.Body.Close();
        }
        /// <summary>
        /// APP更新检查
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        [HttpGet("app_update")]
        //[Route("app_update")]
        public Result AppUpdate(string appid, string version)
        {
            var v = configuration["App:version"];
            var m = configuration["App:msg"];
            var u = configuration["App:url"];
            if (version == "1.0.1" || Convert.ToInt32(v) > Convert.ToInt32(version))
            { //遗留版本
                return Result.Success("有新版本啦，要更新吗").SetData(new { msg = m, url = u });
            }
            return Result.Error("无更新版本");
        }
    }
}