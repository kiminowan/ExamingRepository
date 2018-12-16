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
        public IQuestionService questionService { get; set; }
        /// <summary>
        /// 题目表显示
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions(int knowledgePointID)
        {
            var questionList = questionService.GetQuestions(knowledgePointID);
            return questionList;
        }
        /// <summary>
        /// 获取最后一次练题题目
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        public Question GetRememberQuestion(string openID)
        {
            var question = questionService.GetRemember(openID);
            return question;
        }
    }
}
