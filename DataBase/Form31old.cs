using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataBase
{
    public partial class Form3_1 : Form
    {
        string sid;
        public Form3_1(string sid)
        {
            this.sid = sid;
            InitializeComponent();
            Table();
        }
        //向页面写入数据
        public void Table()
        {
            dataGridView1.Rows.Clear();
            //找到该生的选课
            string sql = "select * from courseRecord where sid = '"+sid+"'";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                //找到对应的每一门课
                string cid = dr["cid"].ToString();
                string sql2 = "select * from course where id = '" + cid + "'";
                //设置新的dr
                IDataReader dr2 = db.read(sql2);
                dr2.Read();
;                //读取数据库中的信息
                string id, name, credit, teacher;
                id = dr2["id"].ToString();
                name = dr2["name"].ToString();
                credit = dr2["credit"].ToString();
                teacher = dr2["teacher"].ToString();
                //写入界面
                string[] str = { id, name, credit, teacher };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();
        } 
        //关闭我的选课
        private void Form3_1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void 删除课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cid = dataGridView1.SelectedCells[0].Value.ToString();
            string sql = "delete courseRecord where cid = '" + cid + "' and sid = '" + sid + "'";
            DB db = new DB();
            db.Execute(sql);
            Table();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Table();
        }
    }
}
