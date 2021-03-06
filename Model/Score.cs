﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //成绩
    [Serializable]
    [Table("Score")]
    public class Score : ID
    {
        public int? CourseId { get; set; }
        [ForeignKey("CourseId")]
        [Display(Name = "课程")]
        public virtual Course Course { get; set; }
        public int? StudentId { get; set; }
        [ForeignKey("StudentId")]
        [Display(Name = "学生")]
        public virtual Student Student { get; set; }
        [Display(Name = "分数")]
        public double Value { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
    }
}