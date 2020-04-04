using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //面试记录
    [Serializable]
    [Table("Interview")]
    public class Interview : ID
    {
        [Display(Name = "姓名")]
        [Required(ErrorMessage = "姓名必填")]
        public string Student_name { get; set; }
        [Display(Name = "班级")]
        public string Student_class { get; set; }
        [Display(Name = "是否参加")]
        public bool Interviewed { get; set; }
        [Display(Name = "提问问题")]
        public string Ask { get; set; }
        [Display(Name = "面试结果")]
        public bool Result { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Display(Name = "应聘公司")]
        public virtual Company Company { get; set; }
    }
}