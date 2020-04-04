using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //在线简历投递
    [Serializable]
    [Table("OnlineResume")]
    public class OnlineResume : ID
    {
        [Display(Name = "企业名称")]
        [Required(ErrorMessage = "区域名称必填")]
        public string Name { get; set; }//企业名称
        [Display(Name = "招聘岗位")]
        public string Post { get; set; }//招聘岗位
        [Display(Name = "薪资")]
        public string Salary { get; set; }
        [Display(Name = "招聘数量")]
        public int? num { get; set; }//招聘数量
        [Display(Name = "面试时间")]
        public DateTime? Interview_time { get; set; }//面试时间
        //第二阶段 出发时间
        [Display(Name = "出发时间")]
        public string Start_time { get; set; }//
        //第三阶段 到达公司
        [Display(Name = "公司图片")]
        public string Company_pic { get; set; }//面试官
        [Display(Name = "到达时间")]
        public string Arrival_time { get; set; }//
         [Display(Name = "公司地址")]
        public string Company_addr { get; set; }
        //第四阶段 面试
        [Display(Name = "面试官")]
        public string Interviewer { get; set; }//面试官
        [Display(Name = "联系方式")]
        public string Interviewer_contact { get; set; }//面试官
        [Display(Name = "提问问题")]
        public string Ask { get; set; }
        [Display(Name = "答案")]
        public string Answer { get; set; }
        [Display(Name = "面试结 束")]
        public string Interviewed_time { get; set; }//
        //第五阶段 面试结果
        [Display(Name = "面试结果")]
        public bool Result { get; set; }
        [Display(Name = "反馈结果")]
        public string Resulted_time { get; set; }//

        [Display(Name = "备注")] 
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }//备注
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        [Display(Name = "学生")]
        public virtual Student Student { get; set; }
    }
}