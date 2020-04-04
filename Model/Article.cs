using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //文章  单篇文章  供学生和老师发表单个文章
    [Serializable]
    [Table("Article")]
    public class Article :ID
    {    
        [Display(Name = "名称")]
        public string Name { get; set; }       
        [Display(Name = "封面")]
        public string Pic { get; set; }      
        [Display(Name = "简介")]
        public string Intro { get; set; }
        [Display(Name = "内容")]
        public string Detail { get; set; }
        /// <summary>
        /// 附件，多个用“;”隔开
        /// </summary>
        [Display(Name = "附件")]
        public string Attach { get; set; }
        /// <summary>
        /// 标签，多个用“;”隔开
        /// </summary>
        [Display(Name = "标签")]
        public string Tag { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}