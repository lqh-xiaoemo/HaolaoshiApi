using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //章节
    [Serializable]
    [Table("Chapter")]
    public class Chapter : TreeID<Chapter>
    {    
        [Display(Name = "名称")]
        public string Name { get; set; }
        public int? CourseId { get; set; } 
        [ForeignKey("CourseId")]
        [Display(Name = "课程")]
        public virtual Course Course { get; set; }
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