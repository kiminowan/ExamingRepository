using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    using Entity;
    public interface IQuestionService
    {
        /// <summary>
        /// 题目表显示
        /// </summary>
        /// <returns></returns>
        List<Question> GetQuestions(int knowledgePointID);
        /// <summary>
        /// 练习题记忆方法
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        Question GetRemember(string openID);
        /// <summary>
        /// 随机取题
        /// </summary>
        /// <returns></returns>
        List<Question> GetQuestionsRandom();
    }
}
