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
    public class AdminAPIController : ApiController
    {
        [Dependency]
        public IAdminService adminService { get; set; }
        /// <summary>
        /// 管理员显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Admin> GetAdmins()
        {
            return adminService.GetAdmins();
        }
    }
}
