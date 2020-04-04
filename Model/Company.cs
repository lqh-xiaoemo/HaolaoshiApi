using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //企业库
    [Serializable]
    [Table("Company")]
    public class Company : ID
    {
     
        [Display(Name = "企业名称")]
        [Required(ErrorMessage = "名称必填")]
        public string Name { get; set; }//企业名称
        [Display(Name = "封面")]
        public string Pic { get; set; }
        [Display(Name = "招聘岗位")]
        public string Post { get; set; }//招聘岗位
        [Display(Name = "薪资")]
        public string Salary { get; set; }
        [Display(Name = "招聘数量")]
        public int? Num { get; set; }//招聘数量
        [Display(Name = "简历提交")]
        public DateTime? Resume_time { get; set; }//面试时间
        [Display(Name = "面试时间")]
        public DateTime? Interview_time { get; set; }//面试时间
        [Display(Name = "面试方式")]
        public string Interview_way { get; set; }
        [Display(Name = "企业规模")]
        public int? Scale { get; set; }//企业规模
        [Display(Name = "备注")]
        [DataType(DataType.MultilineText)]
        public string Memo { get; set; }//备注
        [Display(Name = "附件")]
        public string Attachment { get; set; }//附件
    }
}