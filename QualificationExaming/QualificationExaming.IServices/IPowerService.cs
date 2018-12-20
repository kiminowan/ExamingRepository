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
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        int AddPowers(Power power);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int DelPowers(int id);
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Power GetPowerById(int id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        int Updatepower(Power power);
    }
}
