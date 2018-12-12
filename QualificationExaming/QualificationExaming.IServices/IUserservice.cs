using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    using Entity;
    public interface IUserservice
    {
        User UserLogin(String code);
        List<ErrQuestion> GetErrQuestions(string username);
    }
}
