using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //专业
    [Serializable]
    [Table("Major")]
    public class Major : ID
    {
      
        [Display(Name = "名称")]
        public string Name { get; set; }
        [Display(Name = "封面")]
        public string Pic { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
    }
}