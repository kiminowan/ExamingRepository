using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Entity;
    public interface IErrQuestionService
    {

        /// <summary>
        /// 根据错题id删除错题
        /// </summary>
        /// <param name="erroid"></param>
        /// <returns></returns>
        int DeleteErro(int questionID, string openID);

        /// <summary>
        /// 添加错题
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int AddErro(string openID, int questionID);
        /// <summary>
        /// 根据用户和知识点查询所有错题
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<Question> GetErrQuestionsToShow(string openID, int knowledgePointID);
        /// <summary>
        /// 根据用户查询所有错题
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        List<Question> GetErrQuestions(string openID);
    }
}
