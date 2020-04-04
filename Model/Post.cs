using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //面试岗位
    [Serializable]
    [Table("Post")]
    public class Post : ID
    {
        [Display(Name = "名称")]
        [Required(ErrorMessage = "名称必填")]
        public string Name { get; set; }
        [Display(Name = "封面")]
        public string Pic { get; set; }
        public int? CompanyId { get; set; }
        [ForeignKey("CompanyId")]
        [Display(Name = "所属公司")]
        public virtual Company Company { get; set; }
    }
}