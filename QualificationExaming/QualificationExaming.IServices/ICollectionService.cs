using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Entity;
    public interface ICollectionService
    {
        List<Question> GetCollectionQuestions(string openID);
    }
}
