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
        /// 根据OpenID获取用户错题知识点
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        public List<KnowledgePoint> GetKnowledgePointByOpenID(string openID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var knowledgePointList = conn.Query<KnowledgePoint>("select distinct k.* from KnowledgePoint k join question q on k.KnowledgePointID=q.KnowledgePointID join errquestion e on q.QuestionID=e.QuestionID join `user` u on e.UserID=u.UserID where u.OpenID='" + openID + "'", null);
                if (knowledgePointList != null)
                {
                    return knowledgePointList.ToList();
                }
                return null;
            }
        }
    }
}
