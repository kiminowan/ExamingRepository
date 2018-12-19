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
    using Newtonsoft.Json;
    public class LoginService:ILoginService
    {
        public int Login(string LoginName,string LoginPsw)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = @"select * admin where AdminName=@AdminName and AdminPsw=@AdminPsw";
                var list = conn.Query<Admin>(sql, new { AdminName = LoginName, AdminPsw = LoginPsw }).ToList();
                if(list.Count()>0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}
