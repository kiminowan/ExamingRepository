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
    public class MultimediaApiController : ApiController
    {
        [Dependency]
        public IMultimediaService multimediaService { get; set; }
        /// <summary>
        /// 获取多媒体题库表数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Multimedia> GetMultimedias()
        {
            return multimediaService.GetDuoMei();
        }
    }
}
