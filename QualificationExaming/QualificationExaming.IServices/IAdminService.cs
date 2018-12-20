using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    using Entity;
    public interface IAdminService
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        List<ShowAdmin> GetAdmins();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        int AddAdmin(Admin admin);
        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        IEnumerable<ShowAdmin> showAdmins(int id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        int UpdateAdmin(Admin admin);


    }
}
