using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 题目表
    /// </summary>
    public class Question
    {
        /// <summary>
        /// 题目ID
        /// </summary>
        public int QuestionID { get; set; }
        /// <summary>
        /// 题干
        /// </summary>
        public string QuestionName { get; set; }
        /// <summary>
        /// A选项
        /// </summary>
        public string ChoiceA { get; set; }
        /// <summary>
        /// B选项
        /// </summary>
        public string ChoiceB { get; set; }
        /// <summary>
        /// C选项
        /// </summary>
        public string ChoiceC { get; set; }
        /// <summary>
        /// D选项
        /// </summary>
        public string ChoiceD { get; set; }
        /// <summary>
        /// 答案
        /// </summary>
        public string Answer { get; set; }
        /// <summary>
        /// 知识点ID
        /// </summary>
        public int KnowledgePointID { get; set; }
        /// <summary>
        /// 解析
        /// </summary>
        public string Analysis { get; set; }
        /// <summary>
        /// 题干是否包含图片
        /// </summary>
        public string QuestionHasImg { get; set; }
        /// <summary>
        /// 图片名称
        /// </summary>
        public string QuestionImg { get; set; }
        /// <summary>
        /// 选项是否图片
        /// </summary>
        public string ChoiceIsImg { get; set; }
        /// <summary>
        /// 试卷ID
        /// </summary>
        public int ExamID { get; set; }
        /// <summary>
        /// 题型
        /// </summary>
        public int TypeID { get; set; }
        /// <summary>
        /// 序号
        /// </summary>
        public int Num { get; set; }
    }
}
