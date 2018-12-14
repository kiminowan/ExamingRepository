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
        public List<Role> GetRoles()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var getroleslist = conn.Query<Role>("select * from Role", null);
                if(getroleslist!=null)
                {
                    return getroleslist.ToList();
                }
                return null;
            }
        }
    }
}
