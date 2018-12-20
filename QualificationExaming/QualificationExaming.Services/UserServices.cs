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



    using System.Net.Http;

    using System.Transactions;

    public class UserServices : IUserservice
    {
        /// <summary>
        /// 判断用户是否存在，如果不存在进行创建
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public User UserLogin(String code)
        {

            //using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            //{
            //    conn.Open(); 
            //    string sql = string.Format("INSERT into `user`(UserID, OpenID, Session_key) values('@UserID','@OpenID','@Session_key')");
            //    return conn.Execute(sql, u);
            //}
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                User user = new User();
                HttpClient httpclient = new HttpClient();
                string appid = "wxa91c675de31edc47";
                string secret = "0d7663a55d06f3482e9934e52f4b53e1";
                httpclient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = httpclient.PostAsync("https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + code.ToString() + "&grant_type=authorization_code", null).Result;
                var result = "";
                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;
                }
                httpclient.Dispose();
                var results = JsonConvert.DeserializeObject<User>(result);
                //user.UserID = results.UserID;
                user.OpenID = results.OpenID;
                user.Session_key = results.Session_key;//密钥

                var userList = conn.Query<User>("SELECT * FROM user", null);
                var client = userList.Where(r => r.OpenID.Equals(user.OpenID)).FirstOrDefault();
                //string query = "SELECT * FROM user WHERE OpenID = @OpenID";

                //var book = conn.Query<User>(query, parameters).FirstOrDefault(); 
                //var client = uc.ClientInfo.Where(m => m.OpenId.Equals(clientinfo.OpenID)).FirstOrDefault();//判断是否为已注册用户
                if (client == null)
                {
                    //uc.ClientInfo.Add(clientinfo);
                    //uc.SaveChanges();
                    string sql = string.Format("INSERT into user(OpenID, Session_key) values(@OpenID,@Session_key)");
                    DynamicParameters parameters = new DynamicParameters();
                    parameters.Add("@OpenID", user.OpenID);//@
                    parameters.Add("@Session_key", user.Session_key);
                    conn.Execute(sql, parameters);
                }

                //RedisHelper.Set<User>(user.Session_key, user, DateTime.Now.AddMinutes(10));
                RedisHelper.Set<User>(user.OpenID, user, DateTime.Now.AddHours(1));
                return user;
            }
        }

        public List<Score> GetScore(string code)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var userList = conn.Query<User>("SELECT * FROM user", null);
                var client = userList.Where(r => r.OpenID.Equals(code)).FirstOrDefault();
                var id = client.UserID;
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@id", id);
                string sql = "SELECT * FROM score,exam,`user` WHERE Score.ExamID=exam.ExamID AND Score.UserID=`user`.UserID=@id";
                var result = conn.Query<Score>(sql, parameters).ToList();
                return result;
            }
        }
    }
}
