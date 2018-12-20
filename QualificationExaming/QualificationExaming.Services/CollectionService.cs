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
    public class CollectionService:ICollectionService
    {
        public List<Question> GetCollectionQuestions(string openID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var questionlist = conn.Query<Question>("select q.* from question q join collection c on q.QuestionID=c.QuestionID join `user` u on u.UserID=r.UserID  where u.OpenID='" + openID + "'", null);
                if (questionlist != null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
    }
}
