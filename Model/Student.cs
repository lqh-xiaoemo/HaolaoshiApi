using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    //学生表
    [Serializable]
    [Table("Student")]
    public class Student : Person
    {
        [Required(ErrorMessage = "学号必填")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "学号长度6到40位")]
        public string Sn { get; set; }
        public int ClasssId { get; set; }
        [ForeignKey("ClasssId")]
        [Display(Name = "班级")]
        public virtual Classs Classs { get; set; }
        public String Father { get; set; }//家长
        public String FathertTel { get; set; }//家长
    }
}