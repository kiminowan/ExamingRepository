using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    using Entity;
    public interface IPowerService
    {
        /// <summary>
        /// 权限接口
        /// </summary>
        /// <returns></returns>
        List<Power> GetPowers();
        int AddPowers(Power power);
        int DelPowers(int id);
        Power GetPowerById(int id);
        int Updatepower(Power power);
    }
}
