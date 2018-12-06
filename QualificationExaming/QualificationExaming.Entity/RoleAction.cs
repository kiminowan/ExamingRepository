using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 角色权限表
    /// </summary>
   public class RoleAction
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int RoleActionID { get; set; }
        /// <summary>
        /// 权限ID
        /// </summary>
        public int PowerID { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyTime { get; set; }



        
        
    }
}
