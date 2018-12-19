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
        [HttpGet]
        public int Login(string LoginName, string LoginPsw)
        {
            return loginService.Login(LoginName, LoginPsw);
        }
    }
}
