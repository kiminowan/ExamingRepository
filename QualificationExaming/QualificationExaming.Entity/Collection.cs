using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 收藏表
    /// </summary>
    public class Collection
    {
        /// <summary>
        /// 收藏表id
        /// </summary>
        
        public int CollectionID { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
        public int UserID { get; set; }
        /// <summary>
        /// 题目id
        /// </summary>
        public int QuestionID { get; set; }
        /// <summary>
        /// 题目类型
        /// </summary>
        public int QuestionTypeID { get; set; }
        /// <summary>
        /// 收藏时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
