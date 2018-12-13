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
    public class RememberController : ApiController
    {
        [Dependency]
        public IRememberService rememberService { get; set; }
        [HttpGet]
        public int Addremember(int openID, int questionID)
        {
            return rememberService.Addremember(openID, questionID);
        }
    }
}
