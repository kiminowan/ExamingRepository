﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 用户角色关联表
    /// </summary>
   public class UserRole
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int UserRoleID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 管理员ID
        /// </summary>
        public int AdminID { get; set; }
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
