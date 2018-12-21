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
    public class SourceService:ISourceService
    {
        /// <summary>
        /// 获取资料
        /// </summary>
        /// <returns></returns>
        public List<Source> GetSources()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                var questionlist = conn.Query<Source>("select * from source", null);
                if (questionlist != null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
    }
}
