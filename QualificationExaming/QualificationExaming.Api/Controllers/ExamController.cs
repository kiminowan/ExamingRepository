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

    public class ExamController : ApiController
    {
        [Dependency]
        public IExamService examService { get; set; }

        /// <summary>
        /// 试卷类型表
        /// </summary>
        /// <returns></returns>
        public List<Exam> GetExams()
        {
            return examService.GetExams();

        }
    }
}
