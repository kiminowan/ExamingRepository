using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 登记表
    /// </summary>
    public class Register
    {
        /// <summary>
        /// 登记ID
        /// </summary>
        public int RegisterID { get; set; }
        /// <summary>
        /// 登记人姓名
        /// </summary>
        public string RegisterName { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 科目
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 电话
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 要求
        /// </summary>
        public string Require { get; set; }
    }
}
