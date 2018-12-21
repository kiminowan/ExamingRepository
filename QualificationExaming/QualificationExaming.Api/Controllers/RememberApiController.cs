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
    public class RememberApiController : ApiController
    {
        [Dependency]
        public IRememberService rememberService { get; set; }
        /// <summary>
        /// 做题记录表
        /// </summary>
        /// <param name="openID"></param>
        /// <param name="questionID"></param>
        /// <returns></returns>
        [HttpGet]
        public int AddRemember(string openID, int questionID)
        {
            return rememberService.Addremember(openID, questionID);
        }
    }
}
