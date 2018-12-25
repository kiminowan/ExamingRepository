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
    public class Mistakes
    {
        /// <summary>
        /// 错题表主键id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 题目id
        /// </summary>
        public int QuestionId { get; set; }
        /// <summary>
        /// 错题总数
        /// </summary>
        public int Sum { get; set; }
        /// <summary>
        /// 知识点
        /// </summary>
        public string KnowledgePointName { get; set; }
    }
}
