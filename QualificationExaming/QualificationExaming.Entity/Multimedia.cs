using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Entity
{
    /// <summary>
    /// 多媒体表
    /// </summary>
    public class Multimedia
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
            /// 解析
            /// </summary>
            public string Analysis { get; set; }
            /// <summary>
            /// 视频路径
            /// </summary>
            public string QuestionHasImg { get; set; }
            
        
    }
}
