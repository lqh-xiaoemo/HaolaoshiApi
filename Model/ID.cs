using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
   public class ID
    {
        [Key]
        public int Id { get; set; }
        public DateTime added_time { get; set; } = DateTime.Now;//添加时间
    }
}
