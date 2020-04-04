using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Model
{
    /// <summary>
    /// 区域地址
    /// </summary>
    [Serializable]
    [Table("Area")]
    public class Area : ID
    {
        public Area()
        {
            Childs = new HashSet<Area>();
        }
        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "区域名称必填")]
        public String Name { get; set; }//名称
        public int? ParentId { get; set; }
        [ForeignKey("ParentId")]
        public virtual Area Parent { get; set; }//parent
        public virtual ICollection<Area> Childs { get; set; }
        public int Level { get; set; }//层级
        public bool Expanded { get; set; }//展开
        public bool Common { get; set; }//设为常用
       
    }
}
