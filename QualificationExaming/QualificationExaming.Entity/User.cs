using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 前台用户表
    /// </summary>
    public class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// OpenID
        /// </summary>
        public string OpenID { get; set; }
        /// <summary>
        /// 秘钥
        /// </summary>
        public string Session_key { get; set; }
    }
}
