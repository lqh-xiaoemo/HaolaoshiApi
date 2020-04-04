using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //平时成绩历史
    [Serializable]
    [Table("UsualScoreHistory")]
    public class UsualScoreHistory : ID
    {
        public int? ScoreId { get; set; }
        [ForeignKey("ScoreId")]
        [Display(Name = "平时成绩")]
        public virtual UsualScore Score { get; set; }

        [Display(Name = "项名称")]
        public string Name { get; set; }
        [Display(Name = "项值")]
        public int Value { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
    }
}