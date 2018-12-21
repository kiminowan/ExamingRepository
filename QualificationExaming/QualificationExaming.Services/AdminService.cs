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
    public class AdminService : IAdminService
    {
        /// <summary>
        /// 获取管理员
        /// </summary>
        /// <returns></returns>
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
                if (getadminlist != null)
                {
                    return getadminlist.ToList();
                }
                return null;
            }
        }
        /// <summary>
        /// 添加管理员
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int AddAdmin(Admin admin)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format("insert into Admin(AdminName,AdminPsw,CreateTime,ModifyTime) values(@AdminName,@AdminPsw,NOW(),NOW())");
                var addadmin = conn.Execute(sql, admin);
                string sql1 = string.Format("select AdminID from admin where AdminName=@AdminName");
                var id = conn.Query<int>(sql1, admin).FirstOrDefault();
                var admins = admin.RoleID.Split(',');
                for (int i = 0; i < admins.Length; i++)
                {
                    UserRole userRole = new UserRole();
                    userRole.AdminID = id;
                    userRole.RoleID = Convert.ToInt32(admins[i]);
                    string sql2 = string.Format("insert into UserRole (AdminID,RoleID) values(@AdminID,@RoleID)");
                    var addrole = conn.Execute(sql2, userRole);
                }
                return addadmin;
            }
        }
        /// <summary>
        /// 获取权限根据id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IEnumerable<ShowAdmin> showAdmins(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format(@"select a.AdminName,a.AdminPsw,group_concat(u.RoleID) RoleIds from admin a join userrole u on a.AdminID=u.AdminID where a.AdminID=@AdminID group by a.AdminName,a.AdminPsw");
                var adminlist = conn.Query<ShowAdmin>(sql, new { AdminID = id }).ToList();
                return adminlist;
            }
        }
        /// <summary>
        /// 修改权限
        /// </summary>
        /// <param name="admin"></param>
        /// <returns></returns>
        public int UpdateAdmin(Admin admin)
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                string sql = string.Format("update admin SET AdminName=@AdminName,AdminPsw=@AdminPsw,ModifyTime=NOW() where AdminID=@AdminID");
                var addadmin = conn.Execute(sql, admin);

                var admins = admin.RoleID.Split(',');
                string sql3 = string.Format("delete from userrole where AdminID=@AdminID");
                conn.Execute(sql3, new { AdminID = admin.AdminID });
                conn.Execute(sql3, admin);
                for (int i = 0; i < admins.Length; i++)
                {
                    UserRole userRole = new UserRole();
                    userRole.AdminID = admin.AdminID;
                    userRole.RoleID = Convert.ToInt32(admins[i]);
                    string sql2 = string.Format("insert into UserRole (AdminID,RoleID) values(@AdminID,@RoleID)");
                    var addrole = conn.Execute(sql2, userRole);
                }
                return addadmin;
            }
        }
    }
}
