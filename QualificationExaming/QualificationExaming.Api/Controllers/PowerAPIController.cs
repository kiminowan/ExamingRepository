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
    public class PowerAPIController : ApiController
    {
        [Dependency]
        public IPowerService powerService { get; set; }
        /// <summary>
        /// 权限表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Power> GetPowers()
        {
            return powerService.GetPowers();
        }
    }
}
