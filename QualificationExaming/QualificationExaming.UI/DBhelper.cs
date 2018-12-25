using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clock.DAL
{
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;
    public class DBhelper
    {
        //获得数据库连接字符串
        private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["Exam04StudentDB"].ConnectionString;
        /// <summary>
        /// 执行SQL语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commType">命令类型</param>
        /// <param name="parmeter">sql动态参数</param>
        /// <returns></returns>
        private static SqlCommand ExecuteCommand(string sql, SqlConnection conn, CommandType commType, params SqlParameter[] parmeter)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.CommandType = commType;
            if (parmeter != null)
            {
                cmd.Parameters.AddRange(parmeter);
            }
            return cmd;
        }
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commType"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static DataTable GetTable(string sql, CommandType commType, params SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = ExecuteCommand(sql, conn, commType, parameter))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="commType"></param>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public static int AddOrDeleteOrUpdate(string sql, CommandType commType, params SqlParameter[] parameter)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = ExecuteCommand(sql, conn, commType, parameter))
                {
                    conn.Open();
                    int i = cmd.ExecuteNonQuery();
                    return i;
                }
            }
        }
    }
}
