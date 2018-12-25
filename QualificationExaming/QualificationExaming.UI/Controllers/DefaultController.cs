using Clock.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QualificationExaming.UI.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public JsonResult Index()
        {
            var file = System.Web.HttpContext.Current.Request.Files;
            var name = file[0].FileName;
            return Json(file[0].FileName);
        }
        public string GetExcel()
        {
            //获取所选文件
            HttpPostedFileBase getFile = Request.Files["Excel"];
            if (getFile != null)
            {
                //获得所选文件名
                string fileName = Server.MapPath("~/Content/") + getFile.FileName;
                if (!System.IO.File.Exists(fileName))
                    getFile.SaveAs(fileName);
                //把Excel当做数据源连接
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0;";
                //打开Excel
                OleDbConnection conn = new OleDbConnection(connStr);
                conn.Open();
                //查询Excel
                string sql = "select * from [Sheet1$]";
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                //初始化适配器
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                //获取查出来的Excel表
                adapter.SelectCommand = cmd;
                //初始化dataset并通过适配器赋值
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                //获得ds的第一个表并添加到dataGridView1显示
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sqlStr = string.Format("insert into UsersClock(Department, Name, Num, ClockDate, position) values('{0}','{1}','{2}','{3}','{4}')", dt.Rows[i]["Department"], dt.Rows[i]["Name"], dt.Rows[i]["Num"], dt.Rows[i]["ClockDate"], dt.Rows[i]["position"]);
                    DBhelper.AddOrDeleteOrUpdate(sqlStr, CommandType.Text);
                }
                conn.Close();
                return "导入成功！";
            }
            else
            {
                return "导入失败！";
            }
        }
    }
}