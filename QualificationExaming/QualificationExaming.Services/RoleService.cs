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
        public int AddRole(Role role)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format("insert into role(RoleName,Remake) values(@RoleName,@Remake)");
                var add= conn.Execute(sql, role);
                string sql1 = string.Format("select RoleID from Role where RoleName=@RoleName");
                var id = conn.Query<int>(sql1, role).FirstOrDefault();
                var roles = role.PowerID.Split(',');
                for (int i = 0; i < roles.Length; i++)
                {
                    RoleAction roleAction = new RoleAction();
                    roleAction.RoleID = id;
                    roleAction.PowerID = Convert.ToInt32(roles[i]);
                    string sql2 = string.Format("insert into RoleAction (RoleID,PowerID) values(@RoleID,@PowerID)");
                    var addrole = conn.Execute(sql2, roleAction);
                }
                return add;
            }
                
        }
    }
}
