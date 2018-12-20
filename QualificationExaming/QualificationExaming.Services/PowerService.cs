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

    public class PowerService:IPowerService
    {
        /// <summary>
        /// 权限显示
        /// </summary>
        /// <returns></returns>
        public List<Power> GetPowers()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var getpowerlist = conn.Query<Power>("select * from power", null);
                if(getpowerlist!=null)
                {
                    return getpowerlist.ToList();
                }
                return null;
            }
        }
        /// <summary>
        /// 添加权限
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public int AddPowers(Power power)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@PowerName", power.PowerName);
                parameters.Add("@URL", power.URL);
                parameters.Add("@IsDedate", power.IsDedate);
                string sql = string.Format("insert into Power (PowerName,URL,IsDedate)values(@PowerName,@URL,@IsDedate)");
                var addpowers = conn.Execute(sql, parameters);
                return addpowers;
            }
        }
        /// <summary>
        /// 删除权限
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int DelPowers(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = "delete from power where id=" + id;
                var del = conn.Execute(sql, id);
                return del;
            }
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Power GetPowerById(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = "select * from power where PowerID=@PowerID";
                var getpowerid = conn.Query<Power>(sql, new { PowerID = id}).FirstOrDefault();
                return getpowerid;
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="power"></param>
        /// <returns></returns>
        public int Updatepower(Power power)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format("update power set PowerName=@PowerName,URL=@URL,IsDedate=@IsDedate where PowerID=@PowerID");
                var i = conn.Execute(sql, power);
                return i;
            }
        }
       
    }
}
