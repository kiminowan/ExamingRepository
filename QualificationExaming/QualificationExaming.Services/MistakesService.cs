using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using QualificationExaming.Entity;
    using QualificationExaming.IServices;
    public class MistakesService : IMistakesService
    {
        public int AddMistakes(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@QuestionId", id);


                string sql = string.Format("insert into mistakes(QuestionId) VALUE(@QuestionId)");
                var addpowers = conn.Execute(sql, parameters);
                return addpowers;
            }
        }
        /// <summary>
        /// 根据知识点获取错题
        /// </summary>
        /// <returns></returns>
        public List<Mistakes> GetMistakes()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var userList = conn.Query<Mistakes>("SELECT COUNT(*) sum,c.KnowledgePointName KnowledgePointName from question a JOIN mistakes b on a.QuestionID=b.QuestionId JOIN KnowledgePoint c on a.KnowledgePointID=c.KnowledgePointID GROUP BY a.KnowledgePointID", null).ToList();
                return userList;
            }
        }
    }
}
