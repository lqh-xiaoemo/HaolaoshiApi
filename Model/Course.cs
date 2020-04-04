using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //课程
    [Serializable]
    [Table("Course")]
    public class Course : ID
    {      
        [Display(Name = "名称")]
        public string Name { get; set; }
        [Display(Name = "封面")]
        public string Pic { get; set; }
        [Display(Name = "教材")]
        public string Textbook { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
        /// <summary>
        /// 附件，多个用“;”隔开
        /// </summary>
        [Display(Name = "附件")]
        public string Attach { get; set; }
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } 
        public int? TeacherId { get; set; }
        [ForeignKey("TeacherId")]
        public virtual Teacher Teacher { get; set; }
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}