using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 错题表
    /// </summary>
    public class ErrQuestion
    {
        /// <summary>
        /// 错题主键
        /// </summary>
        public int ErrQuestionID { get; set; }
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
        /// 错题添加时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
