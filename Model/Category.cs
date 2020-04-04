using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Model;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    /// <summary>
    /// 文章、课程分类
    /// </summary>
    [Serializable]
    [Table("Category")]
    public class Category  : TreeID<Category>
    {

        [Display(Name = "名称")]
        [Required(ErrorMessage = "班级名称必填")]
        public string Name { get; set; }    
        [Display(Name = "图片")]
        public string Pic { get; set; }
        [Display(Name = "简介")]
        public string Intro { get; set; }
    }
}