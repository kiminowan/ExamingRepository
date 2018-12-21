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
    public class SourceApiController : ApiController
    {
        [Dependency]
        public ISourceService sourceService { get; set; }
        /// <summary>
        /// 获取资料
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Source> GetSources()
        {
            var sources = sourceService.GetSources();
            if (sources != null)
            {
                return sources.ToList();
            }
            return null;
        }
    }
}
