using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //平时成绩分项
    [Serializable]
    [Table("UsualScoreItem")]
    public class UsualScoreItem : ID
    {
        
        [Display(Name = "名称")]
        public string Name { get; set; }
        [Display(Name = "分项值")]
        public int Value { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
    }
}