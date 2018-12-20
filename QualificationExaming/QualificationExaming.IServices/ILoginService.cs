using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    using Entity;
    public interface ILoginService
    {
        List<Power> GetPowerUrls(int id);
        int Login(string LoginName, string LoginPsw);
    }
}
