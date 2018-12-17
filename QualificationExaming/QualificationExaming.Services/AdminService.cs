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
        public List<ShowAdmin> GetAdmins()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var getadminlist = conn.Query<ShowAdmin>(@"SELECT a.AdminID,a.AdminName,RoleName,a.CreateTime,a.ModifyTime 
from userrole us 
join admin a
on us.AdminID=a.AdminID
join role r
on us.RoleID=r.RoleID", null);
                if(getadminlist!=null)
                {
                    return getadminlist.ToList();
                }
                return null;
            }
        }
        public int AddAdmin(Admin admin)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format("insert into Admin(AdminName,AdminPsw,CreateTime,ModifyTime) values(@AdminName,@AdminPsw,@CreateTime,ModifyTime)");
                var addadmin = conn.Execute(sql, admin);
                return addadmin;
            }
        }
    }
}
