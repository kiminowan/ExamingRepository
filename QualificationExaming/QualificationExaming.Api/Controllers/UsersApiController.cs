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
        /// 获取用户错题
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ErrQuestion> GetErrQuestions(string username)
        {
            return userses.GetErrQuestions(username);
        }
        /// <summary>
        /// 根据错题id进行删除
        /// </summary>
        /// <param name="errid"></param>
        /// <returns></returns>
        [HttpGet]
        public int DeleteErro(int errid)
        {
            return userses.DeleteErro(errid);
        }
        /// <summary>
        /// 错题添加
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        [HttpPost]
        public int AddErro(ErrQuestion e)
        {
            return userses.AddErro(e);
        }
    }
}
