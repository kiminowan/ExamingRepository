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

    public class KnowledgePointService
    {
        /// <summary>
        /// 知识点类型表显示
        /// </summary>
        /// <returns></returns>
        public List<KnowledgePoint>GetKnowledgePointServices()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString);
            return conn.Query<KnowledgePoint>("select * from KnowledgePoint").ToList();
        }
    }
}
