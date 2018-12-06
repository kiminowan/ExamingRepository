using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 资料表
    /// </summary>
    public class Source
    {
        /// <summary>
        /// 资料ID
        /// </summary>
        public int SourceID { get; set; }
        /// <summary>
        /// 资料名称
        /// </summary>
        public string SourceName { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
