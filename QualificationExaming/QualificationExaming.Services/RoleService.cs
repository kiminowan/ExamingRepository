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
    public class RoleService : IRoleService
    {
        /// <summary>
        /// 角色显示
        /// </summary>
        /// <returns></returns>
        public List<ShowRole> GetRolesToShow()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var getroleslist = conn.Query<ShowRole>(@"SELECT a.RoleID,b.RoleName,b.Remake,GROUP_CONCAT(p.PowerName SEPARATOR',') as PowerName 
from roleaction a 
join role b
on a.RoleID=b.RoleID
JOIN power p
on a.PowerID = p.PowerID GROUP BY a.RoleID ,b.RoleName", null);
                if (getroleslist != null)
                {
                    return getroleslist.ToList();
                }
                return null;
            }
        }
        /// <summary>
        /// 显示复选框
        /// </summary>
        /// <returns></returns>
        public List<ShowRole> GetRoles()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var getroleslist = conn.Query<ShowRole>(@"SELECT * from role ", null);
                if (getroleslist != null)
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
                var add = conn.Execute(sql, role);
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
        public IEnumerable<ShowRole> showRoles(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format(@"SELECT r.RoleID,r.RoleName,pr.PowerID ,r.Remake
from role r
join roleaction pr
on r.RoleID=pr.RoleID
where r.RoleID=@RoleID");
                var showrole = conn.Query<ShowRole>(sql, new { RoleID = id }).ToList();
                return showrole;
            }
        }
        public int UpdateRole(Role role)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format("UPDATE role SET RoleName=@RoleName,Remake=@Remake WHERE RoleID=@RoleID");
                var add = conn.Execute(sql, role);

                var roles = role.PowerID.Split(',');
                string sql1 = string.Format("DELETE FROM roleaction where RoleID=@RoleID");
                conn.Execute(sql1, new { RoleID = role.RoleID });

                for (int i = 0; i < roles.Length; i++)
                {
                    RoleAction roleAction = new RoleAction();
                    roleAction.RoleID = role.RoleID;
                    roleAction.PowerID = Convert.ToInt32(roles[i]);
                    string sql2 = string.Format("insert into RoleAction (RoleID,PowerID) values(@RoleID,@PowerID)");
                    var addrole = conn.Execute(sql2, roleAction);
                }
                return add;
            }
        }
    }
}
