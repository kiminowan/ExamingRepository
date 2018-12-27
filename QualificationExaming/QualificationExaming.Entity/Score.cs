using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 成绩表
    /// </summary>
    public class Score
    {
        /// <summary>
        /// 成绩主键
        /// </summary>
        
       public int ScoreID { get; set; }
        /// <summary>
        /// 成绩
        /// </summary>
       public string Scores { get; set; }
        /// <summary>
        /// 试卷id
        /// </summary>
       public int ExamID { get; set; }  
        /// <summary>
        /// 试卷名称
        /// </summary>
        public string ExamName { get; set; }
        /// <summary>
        /// 交卷时间
        /// </summary>
       public DateTime CreateTime { get; set; }
        /// <summary>
        /// 是否随机
        /// </summary>
        public bool isRandom { get; set; }
        /// <summary>
        /// 用户id
        /// </summary>
       public int UserID { get; set; }
    }
}
