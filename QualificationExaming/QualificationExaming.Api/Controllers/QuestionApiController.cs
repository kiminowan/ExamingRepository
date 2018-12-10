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
    public class QuestionApiController : ApiController
    {
        [Dependency]
        public IQuestionService iquestionService { get; set; }
        /// <summary>
        /// 题目表显示
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions()
        {
            return iquestionService.GetQuestions();
        }
    }
}
