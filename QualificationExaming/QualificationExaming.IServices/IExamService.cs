using QualificationExaming.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    public interface IExamService
    {
        /// <summary>
        /// 试卷类型表
        /// </summary>
        /// <returns></returns>
        List<Exam> GetExams();
        /// <summary>
        /// 根据试卷ID获取试题
        /// </summary>
        /// <param name="examID"></param>
        /// <returns></returns>
        List<Question> GetQuestionsByExamID(int examID);
    }
}
