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
    public class CollectionService : ICollectionService
    {
        /// <summary>
        /// 获取收藏题目
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        public List<Question> GetCollectionQuestions(string openID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var questionlist = conn.Query<Question>("select q.* from question q join collection c on q.QuestionID=c.QuestionID join `user` u on u.UserID=c.UserID  where u.OpenID='" + openID + "'", null);
                if (questionlist != null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
        /// <summary>
        /// 根据用户openID和题目ID删除收藏
        /// </summary>
        /// <param name="erroid"></param>
        /// <returns></returns>
        public int DeleteCollection(int questionID, string openID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_questionID", questionID);
                parameters.Add("p_openID", openID);
                var result = conn.Execute("proc_DeleteCollection", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// 添加收藏
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        /// 用户id
        /// 题目id
        public int AddCollection(string openID, int questionID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("p_openID", openID);
                parameters.Add("p_questionID", questionID);
                var result = conn.Execute("proc_AddCollection", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
