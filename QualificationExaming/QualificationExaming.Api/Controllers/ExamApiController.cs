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

    public class ExamApiController : ApiController
    {


        [Dependency]
        public IExamService examService { get; set; }

        [Dependency]
        public IMistakesService mistakes { get; set; }
        /// <summary>
        /// 试卷类型表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Exam> GetExams()
        {
            return examService.GetExams();

        }
        [HttpGet]
        public List<Exam> get()
        {
            var sources = examService.GetExams();
            return sources;
        }
        /// <summary>
        /// 根据知识点获取错题
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Mistakes> GetMistakes()
        {
            return mistakes.GetMistakes();
        }
    }
}
