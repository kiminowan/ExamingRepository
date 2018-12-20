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
    public class LoginService : ILoginService
    {
        /// <summary>
        /// 根据id查询用户名的权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Power> GetPowerUrls(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql1 = "SELECT * FROM power WHERE PowerID IN(select PowerID from roleaction where RoleID IN(SELECT RoleID from userrole WHERE AdminID= @Id))";
                DynamicParameters dynamicParameters1 = new DynamicParameters();
                dynamicParameters1.Add("@Id", id);
                var list1 = conn.Query<Power>(sql1, dynamicParameters1);
                if (list1.Count() > 0)
                {
                    return list1.ToList();
                }
                return null;
            }
        }
        /// <summary>
        /// 通过登录返回当前登录人的id
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="LoginPsw"></param>
        /// <returns></returns>
        public int Login(string LoginName, string LoginPsw)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = "select * from admin where AdminName=@AdminName and AdminPsw=@AdminPsw";
                DynamicParameters dynamicParameters = new DynamicParameters();
                dynamicParameters.Add("@AdminName", LoginName);
                dynamicParameters.Add("@AdminPsw", LoginPsw);
                var list = conn.Query<Admin>(sql, dynamicParameters).ToList();
                if (list.Count() > 0)
                {
                    return list[0].AdminID;
                }
                else
                {
                    return 0;
                }
            }
        }
    }
}

