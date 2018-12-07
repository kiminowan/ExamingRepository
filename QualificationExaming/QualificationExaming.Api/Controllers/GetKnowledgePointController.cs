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
    public class GetKnowledgePointController : ApiController
    {
        [Dependency]
        public KnowledgePointIService kdpi { get; set; }
        public List<KnowledgePoint> GetKnowledgePointServices()
        {
            return kdpi.GetKnowledgePointServices();
        }
    }
}
