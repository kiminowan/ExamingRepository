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
    public class ScoreService:IScoreService
    {
        /// <summary>
        /// 获取成绩
        /// </summary>
        /// <param name="openID"></param>
        /// <returns></returns>
        public List<Score> GetScores(string openID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var questionlist = conn.Query<Score>("select s.*,e.ExamName from score s join exam e on s.ExamID=e.ExamID join `user` u on u.UserID=s.UserID  where u.OpenID='" + openID + "' ORDER BY s.CreateTime DESC", null);
                if (questionlist != null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
        /// <summary>
        /// 添加成绩
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        /// 用户id
        /// 题目id
        public int AddScore(string openID, int examID,int score, bool isRandom)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_openID", openID);
                parameters.Add("p_examID", examID);
                parameters.Add("p_score", score);
                parameters.Add("p_isRandom", isRandom);
                var result = conn.Query<int>("proc_AddScore", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result.FirstOrDefault();
            }
        }
        /// <summary>
        /// 获取成绩根据用户id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Score> GetScoresByid(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var questionlist = conn.Query<Score>("select s.*,e.ExamName from score s join exam e on s.ExamID=e.ExamID where s.ScoreID=" + id , null);

                if (questionlist != null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
    }
}
