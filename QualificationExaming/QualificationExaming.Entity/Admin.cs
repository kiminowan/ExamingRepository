using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 后台用户表
    /// </summary>
   public class Admin
    {
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AdminID { get; set; }
        /// <summary>
        /// 管理员名称
        /// </summary>
        public string AdminName { get; set; }
        /// <summary>
        /// 管理员密码
        /// </summary>
        public string AdminPsw { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public string RoleID { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string CreateTime { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        public string ModifyTime { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public int IsDedate { get; set; }
    }
}
