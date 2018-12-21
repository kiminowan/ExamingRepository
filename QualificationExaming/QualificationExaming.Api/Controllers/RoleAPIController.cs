using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QualificationExaming.Api.Controllers
{
    using Entity;
    using IServices;
    using Services;
    using Unity.Attributes;
    [RoutePrefix("RoleAPI")]
    public class RoleApiController : ApiController
    {
        [Dependency]
        public IRoleService roleService { get; set; }
        /// <summary>
        /// 角色显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ShowRole> GetRolesToShow()
        {
            return roleService.GetRolesToShow();
        }
        /// <summary>
        /// 角色复选框
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ShowRole> GetRoles()
        {
            return roleService.GetRoles();
        }
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddRole")]
        public int AddRole(Role role)
        {
            //Role role = new Role();
            //role.RoleName = RoleName;
            //role.Remake = Remake;
            //role.PowerID = PowerID;
            return roleService.AddRole(role);

        }
        /// <summary>
        /// 获取信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<ShowRole> showRoles(int id)
        {
            return roleService.showRoles(id);
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost]
        public int UpdateRole(Role role)
        {
            return roleService.UpdateRole(role);
        }
    }
}
