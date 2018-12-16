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
    public class RoleService:IRoleService
    {
        /// <summary>
        /// 角色显示
        /// </summary>
        /// <returns></returns>
        public List<ShowRole> GetRoles()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var getroleslist = conn.Query<ShowRole>(@"SELECT a.RoleID,b.RoleName,b.Remake,GROUP_CONCAT(p.PowerName SEPARATOR',') as PowerName 
from roleaction a 
join role b
on a.RoleID=b.RoleID
JOIN power p
on a.PowerID = p.PowerID GROUP BY a.RoleID ,b.RoleName", null);
                if(getroleslist!=null)
                {
                    return getroleslist.ToList();
                }
                return null;
            }
        }
    }
}
