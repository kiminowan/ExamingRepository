using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.IServices
{
    using Entity;
    public interface IRoleService
    {
        /// <summary>
        /// 角色接口
        /// </summary>
        /// <returns></returns>
        List<ShowRole> GetRolesToShow();
        /// <summary>
        /// 获取
        /// </summary>
        /// <returns></returns>
        List<ShowRole> GetRoles();
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int AddRole(Role role);
        IEnumerable<ShowRole> showRoles(int id);
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        int UpdateRole(Role role);
    }
}
