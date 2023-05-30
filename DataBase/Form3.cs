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
    public partial class Form3 : Form
    {
        string Sno;//记录登录选课系统的学号
        public Form3(string sno)
        {
            Sno = sno;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            toolStripStatusLabel1.Text = "欢迎学号为" + sno + "的同学登录学生选课系统";
            timer1.Start();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from course";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h, i;
                a = dr["cno"].ToString();
                b = dr["cname"].ToString();
                c = dr["ctype"].ToString();
                d = dr["csize"].ToString();
                e = dr["ctime"].ToString();
                f = dr["ccredit"].ToString();
                g = dr["cteacher"].ToString();
                h = dr["croom"].ToString();
                i = dr["cdepartment"].ToString();
                string[] str = { a, b, c, d, e, f, g, h, i };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void 选课ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cno = dataGridView1.SelectedCells[0].Value.ToString();//获取选中的课程号
            string sql1 = "select * from courseRecord where sno='" + Sno + "' and cno='" + cno + "'";
            DB db = new DB();
            IDataReader dc = db.read(sql1);
            if(!dc.Read())
            {
                string sql = "insert into courseRecord values('"+cno+"','"+Sno+"')";
                int i = db.Execute(sql);
                if(i>0)
                {
                MessageBox.Show("选课成功");
                }
            }
            else
            {
                MessageBox.Show("不允许重复选课");
            }
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void 我的课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form31 f = new Form31(Sno);
            f.Show();
        }

        private void 系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 修改个人密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form32 f =  new Form32(Sno);
            f.ShowDialog();

        }

        private void 成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form33 f = new Form33(Sno);
            f.Show();
        }

        private void 查询个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Form34 f = new Form34(Sno);
            f.Show();
        }

        private void 查看教室地点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form25 f = new Form25();
            f.Show();
        }
    }
}
