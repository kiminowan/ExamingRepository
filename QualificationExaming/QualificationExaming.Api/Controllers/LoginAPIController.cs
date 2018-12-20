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
    public class LoginAPIController : ApiController
    {
        [Dependency]
        public ILoginService loginService { get; set; }
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public List<Power> GetPowerUrls(int id)
        {
            return loginService.GetPowerUrls(id);
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPsw"></param>
        /// <returns></returns>
        [HttpGet]
        public int Login(string LoginName, string LoginPsw)
        {
            return loginService.Login(LoginName, LoginPsw);
        }
    }
}
