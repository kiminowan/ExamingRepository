using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    public interface IRememberService
    {
        int Addremember(string openID, int questionID);
    }
}
