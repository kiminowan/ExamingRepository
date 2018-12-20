using Dapper;
using MySql.Data.MySqlClient;
using QualificationExaming.Entity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace QualificationExaming.Services
{
    using IServices;
    public class MultimediaService:IMultimediaService
    {
        /// <summary>
        /// 多媒体题目表显示
        /// </summary>
        /// <returns></returns>
        public List<Multimedia> GetDuoMei()
        {
            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
            {
                //DynamicParameters parameters = new DynamicParameters();
                //parameters.Add("p_knowledgePointID", knowledgePointID);
                var questionlist = conn.Query<Multimedia>("select * from duomeiti", null);
                if (questionlist != null)
                {
                    return questionlist.ToList();
                }
                return null;
            }
        }
    }
}
