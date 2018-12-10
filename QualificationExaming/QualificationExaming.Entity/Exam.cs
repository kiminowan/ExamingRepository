using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 试卷表
    /// </summary>
    public class Exam
    {
        /// <summary>
        /// 试卷id
        /// </summary>
        public int ExamID {get;set;} 
        /// <summary>
        /// 试卷名称
        /// </summary>
        public string ExamName { get; set; }
    }
}
