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
    public class ErrQuestionService : IErrQuestionService
    {

        /// <summary>
        /// 根据错题id删除错题
        /// </summary>
        /// <param name="erroid"></param>
        /// <returns></returns>
        public int DeleteErro(int erroid)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();

                parameters.Add("p_errquestionid", erroid);
                var result = conn.Execute("proc_DeleteErrQuestion", parameters, commandType: System.Data.CommandType.StoredProcedure);
                return result;
            }
        }

        /// <summary>
        /// 添加错题
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        /// 用户id
        /// 题目id
        public int AddErro(string openID, int questionID)
        {
            //查找该用户错题集中是否有该题
            var question= GetErrQuestions(openID).Find(m=>m.QuestionID==questionID);
            if (question == null)
            {
                using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
                {
                    DynamicParameters parameters = new DynamicParameters();

                    parameters.Add("p_openID", openID);
                    parameters.Add("p_questionID", questionID);
                    var result = conn.Execute("proc_AddErrQuestion", parameters, commandType: System.Data.CommandType.StoredProcedure);
                    return result;
                }
            }
            return 0;
        }
        /// <summary>
        /// 根据用户和知识点查询所有错题
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<Question> GetErrQuestionsToShow(string openID,int knowledgePointID)
        {
            var questions = GetErrQuestions(openID).Where(m => m.KnowledgePointID == knowledgePointID);
            if (questions != null)
            {
                return questions.ToList();
            }
            return null;
        }
        public List<Question> GetErrQuestions(string openID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var userList = conn.Query<User>("SELECT * FROM user", null);
                var client = userList.Where(r => r.OpenID.Equals(openID)).FirstOrDefault();
                var id = client.UserID;
                string sql = string.Format("select q.* from question q join errquestion e on q.QuestionID=e.QuestionID  WHERE UserID="+ id);
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("_UserID", id);//@
                var eroo = conn.Query<Question>(sql, null);
                if (eroo != null)
                {
                    List<Question> questionList = eroo.ToList();
                    for(int i = 1; i <= questionList.Count(); i++)
                    {
                        questionList[i-1].Num = i;
                    }
                    return questionList;
                }
                return null;
            }
        }
    }
}
