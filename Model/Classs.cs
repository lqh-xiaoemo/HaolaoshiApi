using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //班级
    [Serializable]
    [Table("Classs")]
    public class Classs : ID
    {

        [Display(Name = "名称")]
        [Required(ErrorMessage = "班级名称必填")]
        public string Name { get; set; }
        public int? GradeId { get; set; }
        [ForeignKey("GradeId")]
        [Display(Name = "年级")]
        public virtual Grade Grade { get; set; }
        public int? MajorId { get; set; }
        [ForeignKey("MajorId")]
        [Display(Name = "专业")]
        public virtual Major Major { get; set; }
        [Display(Name = "封面")]
        public string Pic { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
    }
}