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
    public class PowerService
    {
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
    }
}
