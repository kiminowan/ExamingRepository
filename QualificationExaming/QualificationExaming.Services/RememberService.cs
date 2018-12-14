using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QualificationExaming.Services
{
    using Entity;
    using MySql.Data.MySqlClient;
    using Dapper;
    using System.Configuration;
    using IServices;

    public class RememberService:IRememberService
    {
        public int Addremember(string openID,int questionID)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("p_openID", openID);
                parameters.Add("p_questionID", questionID);
                var result= conn.Execute("p_AddRemember", parameters,commandType:System.Data.CommandType.StoredProcedure);
                return result;
            }
        }
    }
}
