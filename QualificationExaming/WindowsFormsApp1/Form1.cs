using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable dt;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //提示打开文件
                OpenFileDialog file = new OpenFileDialog();
                //筛选文件格式
                file.Filter = "Excel(*.xls)|*.xls|Excel(*.xlsx)|*.xlsx";
                //如果点击取消就返回
                if (file.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                //获得所选文件名
                string fileName = file.FileName;
                //把Excel当做数据源连接
                String sConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties=Excel 12.0;";
                //打开Excel数据源
                OleDbConnection conn = new OleDbConnection(sConnectionString);
                conn.Open();
                //查询Excel表语句
                string sql = "select * from [Sheet1$]";
                //执行sql语句
                OleDbCommand cmd = new OleDbCommand(sql, conn);
                //打开适配器
                OleDbDataAdapter adapter = new OleDbDataAdapter();
                //获得的数据放到适配器
                adapter.SelectCommand = cmd;
                //定义DataSet
                DataSet ds = new DataSet();
                //数据放到DataSet
                adapter.Fill(ds);
                //获得DataSet第一个表dataTable
                dt = ds.Tables[0];
                //数据显示到dataGridView1
                this.dataGridView1.DataSource = dt;
                //循环表
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    //获得添加的sql语句 并执行
                    string stuSQL = string.Format("insert into question(QuestionName, ChoiceA, ChoiceB, ChoiceC, ChoiceD,Answer,KnowledgePointID,Analysis,QuestionHasImg,QuestionImg,ChoiceIsImg,ExamID,TypeID) values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}')", dt.Rows[i]["题干"], dt.Rows[i]["A选项(选项若为图片则写图片名称带扩展名)"], dt.Rows[i]["B选项"], dt.Rows[i]["C选项"], dt.Rows[i]["D选项"], dt.Rows[i]["答案（多选题为ABCD的组合，判断题A为对B为错）"], dt.Rows[i]["知识点ID"], dt.Rows[i]["解析"], dt.Rows[i]["题干是否有图片(1为有，0为没有)"], dt.Rows[i]["题干图片名称带扩展名(没有则留空)"], dt.Rows[i]["选项是否为图片(1为有，0为没有)"], dt.Rows[i]["所属考卷ID"], dt.Rows[i]["类型（单选、多选、判断）"]);
                    DBhelp.AddOrDelteOrUpdate(stuSQL, CommandType.Text);
                }
                //关闭数据源
                conn.Close();
                //提示
                MessageBox.Show("导入成功！");
            }
            //抛出异常
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
