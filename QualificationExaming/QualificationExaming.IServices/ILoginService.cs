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
        /// <summary>
        /// 获取接口
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        List<Power> GetPowerUrls(int id);
        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPsw"></param>
        /// <returns></returns>
        int Login(string LoginName, string LoginPsw);
    }
}
