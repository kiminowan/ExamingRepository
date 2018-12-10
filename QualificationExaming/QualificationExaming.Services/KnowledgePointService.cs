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

    public class KnowledgePointService:IKnowledgePointService
    {
        /// <summary>
        /// 知识点类型表显示
        /// </summary>
        /// <returns></returns>
        public List<KnowledgePoint> GetKnowledgePoint()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var knowledgePointList= conn.Query<KnowledgePoint>("select * from KnowledgePoint", null);
                if (knowledgePointList != null)
                {
                    return knowledgePointList.ToList();
                }
                return null;
            }
        }
        /// <summary>
        /// 题目表显示
        /// </summary>
        /// <returns></returns>
        public List<Question> GetQuestions()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var questionlist = conn.Query<Question>("select * from question where TypeID=1", null);
                if(questionlist!=null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
    }
}
