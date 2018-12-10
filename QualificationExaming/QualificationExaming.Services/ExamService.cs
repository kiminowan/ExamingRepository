using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Services;
    using Dapper;
    using IServices;
    using MySql.Data.MySqlClient;
    using System.Configuration;
    using Entity;

    public class ExamService:IExamService
    {
        /// <summary>
        /// 试卷类型表
        /// </summary>
        /// <returns></returns>
        public List<Exam> GetExams()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var examList = conn.Query<Exam>("select * from Exam", null);
                if (examList != null)
                {
                    return examList.ToList();
                }
                return null;


            }

        }
    }
}
