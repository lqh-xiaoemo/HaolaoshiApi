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
    [Table("Teacher")]
    public class Teacher : Person
    {
        public Teacher()
        {
            Classses = new HashSet<Classs>();
        }
        [Required(ErrorMessage = "工号必填")]
        [StringLength(40, MinimumLength = 6, ErrorMessage = "工号长度6到40位")]
        public string Sn { get; set; }
        public virtual ICollection<Classs> Classses { get; set; }
    }
}