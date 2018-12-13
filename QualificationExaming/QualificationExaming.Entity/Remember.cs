using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 顺序练题记忆表
    /// </summary>
    public class Remember
    {
        /// <summary>
        /// 记忆表id
        /// </summary>
       
       public int RememberID { get; set; }
        /// <summary>
        /// 做题时间
        /// </summary>
       public DateTime CreateTime { get; set; }
        /// <summary>
        /// 题目Id
        /// </summary>
       public int QuestionID { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
       public int UserID { get; set; } 

    }
}
