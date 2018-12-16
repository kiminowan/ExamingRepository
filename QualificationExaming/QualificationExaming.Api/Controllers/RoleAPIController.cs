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
    public class RoleAPIController : ApiController
    {
        [Dependency]
        public IRoleService roleService { get; set; }
        /// <summary>
        /// 角色显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<ShowRole> GetRoles()
        {
            return roleService.GetRoles();
        }
    }
}
