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
    [RequestAuthorize]
    public class UsersApiController : ApiController
    {
        [Dependency]
        public IUserservice userses { get; set; }
        /// <summary>
        /// 获取用户的成绩表
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public List<Score> GetScores(string code)
        {
            return userses.GetScore(code);
        }
    }
}
