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
        List<Question> GetQuestions(int knowledgePointID);
        Question GetRemember(string openID);
    }
}
