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
        List<ShowRole> GetRoles();
        int AddRole(Role role);
        IEnumerable<ShowRole> showRoles(int id);
        int UpdateRole(Role role);
    }
}
