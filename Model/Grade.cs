﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //年级
    [Serializable]
    [Table("Grade")]
    public class Grade : ID
    {

        [Display(Name = "名称")]
        [Required(ErrorMessage = "年级名称必填")]
        public string Name { get; set; }
        [Display(Name = "封面")]
        public string Pic { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
    }
}