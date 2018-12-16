using MySql.Data.MySqlClient;
using QualificationExaming.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Dapper;
    using IServices;
    public class QuestionService:IQuestionService
    {
        /// <summary>
        /// 题目表显示
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions(int knowledgePointID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_knowledgePointID", knowledgePointID);
                var questionlist = conn.Query<Question>("select * from question", null);
                if (questionlist != null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
        public Question GetRemember(string openID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var questionlist = conn.Query<Question>("select * from question q join remember r on q.QuestionID=r.QuestionID join `user` u on u.UserID=r.UserID  where u.OpenID='"+ openID + "' ORDER BY(r.CreateTime) DESC ", null);
                if (questionlist != null)
                {
                    return questionlist.FirstOrDefault();
                }
                return null;
            }
        }
    }
}
