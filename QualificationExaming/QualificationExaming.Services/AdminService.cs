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
    public class AdminService:IAdminService
    {
        public List<Admin> GetAdmins()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var getadminlist = conn.Query<Admin>("select * from admin", null);
                if(getadminlist!=null)
                {
                    return getadminlist.ToList();
                }
                return null;
            }
        }
    }
}
