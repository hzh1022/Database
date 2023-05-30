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
    public partial class Form2 : Form
    {
        string Tno;
        public Form2(string tno)
        {
            Tno = tno;
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void toolStripStatusLabel4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from student";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while(dr.Read())
            {
                string sno, sname, ssex, sbirth, sclass, scourse, sdepartment;
                sno = dr["sno"].ToString();
                sname = dr["sname"].ToString();
                ssex = dr["ssex"].ToString();
                sbirth = dr["sbirth"].ToString();
                sclass = dr["sclass"].ToString();
                //scourse = dr["scourse"].ToString();
                sdepartment = dr["sdepartment"].ToString();
                string[] str = { sno, sname, ssex, sbirth, sclass,sdepartment };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void 添加学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form21 f = new Form21();
            f.ShowDialog();
            Table();
        }

        private void 修改学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] str = { dataGridView1.SelectedCells[0].Value.ToString(), dataGridView1.SelectedCells[1].Value.ToString(), dataGridView1.SelectedCells[2].Value.ToString(), dataGridView1.SelectedCells[3].Value.ToString(), dataGridView1.SelectedCells[4].Value.ToString(), dataGridView1.SelectedCells[5].Value.ToString(), dataGridView1.SelectedCells[6].Value.ToString() };
            Form21 f = new Form21(str);
            f.ShowDialog();
        }

        private void 删除学生信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.OKCancel);
            if(r == DialogResult.OK)
            {
                string sno, sname;
                sno = dataGridView1.SelectedCells[0].Value.ToString();
                sname = dataGridView1.SelectedCells[1].Value.ToString();
                string sql = "delete from student where sno='" + sno + "' and sname='" + sname + "'";
                DB db = new DB();
                db.Execute(sql);
                Table();
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 汇入成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form22 f = new Form22();
            f.ShowDialog();
            Table();
        }

        private void 查看成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form23 f = new Form23();
            f.Show();
        }

        private void 查看班级绩点排名ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form24 f = new Form24();
            f.Show();
        }

        private void 查看课程地点ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form25 f = new Form25();
            f.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 查询个人信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form299 f = new Form299(Tno);
            f.Show();
        }
    }
}
