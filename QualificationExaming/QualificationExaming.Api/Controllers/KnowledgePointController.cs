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
    public class KnowledgePointApiController : ApiController
    {
        [Dependency]
        public IKnowledgePointService kdpi { get; set; }
        [Dependency]
        public IUserservice userservice { get; set; }
        /// <summary>
        /// 知识点类型表显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<KnowledgePoint> GetKnowledgePoint()
        {
            return kdpi.GetKnowledgePoint();
        }

        [HttpGet]
        public User Login(string code)
        {
            var client = userservice.UserLogin(code);
            return client;
        }

    }
}
