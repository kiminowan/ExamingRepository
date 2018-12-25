using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MySql.Data.MySqlClient;
using System.Data;
using System.Configuration;
using System.Collections;
public class DBhelp
{
    //获得数据库连接字符串
    //private static readonly string ConnectionString = ConfigurationManager.ConnectionStrings["StudentDB"].ConnectionString;
    private static string ConnectionString = "server=172.25.53.26;user id=root;password=fense0415sx;database=db_examing;sslmode=none;";
    /// <summary>
    /// sql语句查询返回datatable
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static DataTable GetTabel(string sql, CommandType commandType, params MySqlParameter[] parameters)
    {
        MySqlConnection conn = new MySqlConnection(ConnectionString);
        DataTable dt = new DataTable();
        try
        {
            conn.Open();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, conn);
            adapter.SelectCommand.CommandType = commandType;
            adapter.SelectCommand.Parameters.AddRange(parameters);
            adapter.Fill(dt);
        }
        catch (Exception ex)
        {
            dt = null;
            throw ex;
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            conn = null;
        }
        return dt;
    }
    /// <summary>
    /// 执行sql语句添加 删除 修改
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static int AddOrDelteOrUpdate(string sql, CommandType commandType, params MySqlParameter[] parameters)
    {
        MySqlConnection conn = new MySqlConnection(ConnectionString);
        try
        {
            conn.Open();
        }
        catch (MySqlException ex)
        {
            // 获取描述当前异常的消息。
            // 返回结果:解释异常原因的错误消息或空字符串 ("")。
            throw new Exception(ex.Message);
        }
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        cmd.CommandType = commandType;
        cmd.Parameters.AddRange(parameters);
        try
        {
            cmd.Prepare();
            int i = cmd.ExecuteNonQuery();
            return i;
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            conn = null;
            cmd.Dispose();
            cmd = null;
        }
    }

    /// <summary>
    /// 执行批删 批修
    /// </summary>
    /// <param name="sqlList"></param>
    public static void AllDelteOrAllUpdate(ArrayList sqlList)
    {
        using (MySqlConnection conn = new MySqlConnection(ConnectionString))
        {
            conn.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = conn;
            MySqlTransaction trans = conn.BeginTransaction();
            cmd.Transaction = trans;
            try
            {
                for (int i = 0; i < sqlList.Count; i++)
                {
                    string sql = sqlList[i].ToString();
                    if (sql.Trim().Length > 1)
                    {
                        cmd.CommandText = sql;
                        cmd.ExecuteNonQuery();
                    }
                }
                trans.Commit();
            }
            catch (Exception ex)
            {
                trans.Rollback();
                throw ex;
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                trans.Dispose();
            }
        }
    }

    /// <summary>
    /// 登陆
    /// </summary>
    /// <param name="sql"></param>
    /// <returns></returns>
    public static object Login(string sql)
    {
        MySqlConnection conn = new MySqlConnection(ConnectionString);

        try
        {
            conn.Open();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        MySqlCommand cmd = new MySqlCommand(sql, conn);
        try
        {
            cmd.Prepare();
            return cmd.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw (ex);
        }
        finally
        {
            conn.Close();
            conn.Dispose();
            conn = null;
            cmd.Dispose();
            cmd = null;
        }
    }

    /// <summary>
    /// 分页存储过程
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <param name="pageIndex">当前页</param>
    /// <param name="pageSize">每页几条数据</param>
    /// <param name="dataCount">总数据条数</param>
    /// <returns></returns>
    //public static DataTable FenYen(string sql,int pageIndex,int pageSize,out int dataCount)
    //{
    //    MySqlConnection conn = new MySqlConnection(ConnectionString);

    //    try
    //    {
    //        conn.Open();
    //    }
    //    catch(Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //    try
    //    {
    //        MySqlCommand cmd = new MySqlCommand();
    //        cmd.CommandText = "";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Connection = conn;
    //        cmd.Parameters.Clear();
    //        MySqlParameter[] parameter = new MySqlParameter[]
    //        {
    //            new MySqlParameter("",sql),
    //            new MySqlParameter("",pageIndex),
    //            new MySqlParameter("",pageSize),
    //            new MySqlParameter("",MySqlDbType.Int32),
    //        };
    //        parameter[3].Direction = ParameterDirection.Output;

    //        cmd.Parameters.Add(parameter);

    //        MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
    //        DataTable dt = new DataTable();
    //        adapter.Fill(dt);
    //        dataCount = Convert.ToInt32(parameter[3].Value);
    //        adapter.Dispose();
    //        return dt;
    //    }
    //    catch(Exception ex)
    //    {
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        conn.Close();
    //        conn.Dispose();
    //        conn = null;
    //    }

    //}

    /// <summary>
    /// 存储过程 添加 删除  修改
    /// </summary>
    /// <returns></returns>
    //public static int ProcAddOrDelteOrUpdate(string m)
    //{
    //    MySqlConnection conn = new MySqlConnection(ConnectionString);

    //    try
    //    {
    //        conn.Open();
    //    }
    //    catch(Exception ex)
    //    {
    //        throw new Exception(ex.Message);
    //    }
    //    try
    //    {
    //        MySqlCommand cmd = new MySqlCommand();
    //        cmd.CommandText = "";
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Connection = conn;

    //        cmd.Parameters.Clear();

    //        cmd.Parameters.AddRange(parameter);
    //        return cmd.ExecuteNonQuery();
    //    }
    //    catch(Exception ex)
    //    {
    //        throw (ex);
    //    }
    //    finally
    //    {
    //        conn.Close();
    //        conn.Dispose();
    //        conn = null;
    //    }
    //}

}
