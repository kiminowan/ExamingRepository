using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QualificationExaming.Api.Controllers
{
    using Entity;
    using IServices;
    using Services;
    using System.Web;
    using Unity.Attributes;
    using System.IO;
    using System.Data.OleDb;
    using System.Data;
    using MySql.Data;
    using MySql.Data.MySqlClient;
    using Dapper;
    using System.Configuration;

    public class ExamApiController : ApiController
    {


        [Dependency]
        public IExamService examService { get; set; }

        [Dependency]
        public IMistakesService mistakes { get; set; }
        /// <summary>
        /// 试卷类型表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Exam> GetExams()
        {
            return examService.GetExams();

        }
        [HttpGet]
        public List<Exam> get()
        {
            var sources = examService.GetExams();
            return sources;
        }
        /// <summary>
        /// 根据知识点获取错题
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Mistakes> GetMistakes()
        {
            return mistakes.GetMistakes();
        }
        /// <summary>
        /// 根据试卷ID获取试题
        /// </summary>
        /// <param name="examID"></param>
        /// <returns></returns>
        public List<Question> GetQuestionsByExamID(int examID)
        {
            return examService.GetQuestionsByExamID(examID);
        }
        public int QuestionImport()
        {
            //获取所选文件
            HttpPostedFile getFile =HttpContext.Current.Request.Files["Excel"];
            if (getFile != null)
            {
                //获得所选文件名
                string fileName = HttpContext.Current.Request.MapPath("~/Content/") + getFile.FileName;
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
                DataTable dt = ds.Tables[0];
                using (MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["connString"].ConnectionString))
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //获得添加的sql语句 并执行
                        string stuSQL = string.Format("insert into question(QuestionName, ChoiceA, ChoiceB, ChoiceC, ChoiceD,Answer,KnowledgePointID,Analysis,QuestionHasImg,QuestionImg,ChoiceIsImg,ExamID,TypeID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", dt.Rows[i]["题干"], dt.Rows[i]["A选项(选项若为图片则写图片名称带扩展名)"], dt.Rows[i]["B选项"], dt.Rows[i]["C选项"], dt.Rows[i]["D选项"], dt.Rows[i]["答案（多选题为ABCD的组合，判断题A为对B为错）"], dt.Rows[i]["知识点ID"], dt.Rows[i]["解析"], dt.Rows[i]["题干是否有图片(1为有，0为没有)"], dt.Rows[i]["题干图片名称带扩展名(没有则留空)"], dt.Rows[i]["选项是否为图片(1为有，0为没有)"], dt.Rows[i]["所属考卷ID"], dt.Rows[i]["类型（单选、多选、判断）"]);
                        var addpowers = mySqlConnection.Execute(stuSQL, null);
                    }
                }
                conn.Close();
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
