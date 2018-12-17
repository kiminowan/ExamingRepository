using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 权限表
    /// </summary>
   public class Power
    {
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PowerID { get; set; }
        /// <summary>
        /// 权限名称
        /// </summary>
        public string PowerName { get; set; }
        /// <summary>
        /// 路径  
        /// </summary>
        public string URL { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsDedate { get; set; }
        
        
        
    }
}
