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
    public class CollectionApiController : ApiController
    {
        [Dependency]
        public ICollectionService collectionService { get; set; }
        /// <summary>
        /// 获取收藏题目
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        public List<Question> GetQuestions(string openID)
        {
            var questions = collectionService.GetCollectionQuestions(openID);
            if (questions != null)
            {
                return questions.ToList();
            }
            return null;
        }
        /// <summary>
        /// 删除收藏
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="openID"></param>
        /// <returns></returns>
        [HttpGet]
        public int DeleteCollection(int questionID, string openID)
        {
            var result = collectionService.DeleteCollection(questionID, openID);
            return result;
        }
        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="questionID"></param>
        /// <param name="openID"></param>
        /// <returns></returns>
        [HttpGet]
        public int AddCollection(string openID, int questionID)
        {
            var result = collectionService.AddCollection(openID, questionID );
            return result;
        }
    }
}
