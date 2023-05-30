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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            timer1.Start();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from teacher";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g;
                a = dr["tno"].ToString();
                b = dr["tcode"].ToString();
                c = dr["tname"].ToString();
                d = dr["ttel"].ToString();
                e = dr["tposition"].ToString();
                f = dr["tdepartment"].ToString();
                g = dr["tcourse"].ToString();
                string[] str = { a, b, c, d, e, f, g };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();//结束整个程序
        }

        private void 添加教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form41 f = new Form41(this);
            f.ShowDialog();
        }

        private void 修改教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string a, b, c, d, g, h, i;
            a = dataGridView1.SelectedCells[0].Value.ToString();
            b = dataGridView1.SelectedCells[1].Value.ToString();
            c = dataGridView1.SelectedCells[2].Value.ToString();
            d = dataGridView1.SelectedCells[3].Value.ToString();
            g = dataGridView1.SelectedCells[4].Value.ToString();
            h = dataGridView1.SelectedCells[5].Value.ToString();
            i = dataGridView1.SelectedCells[6].Value.ToString();
            string[] str = { a, b, c, d, g, h, i};
            Form41 f = new Form41(str,this);
            f.ShowDialog();
        }

        private void 删除教师信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult r = MessageBox.Show("确认删除吗？", "提示", MessageBoxButtons.OKCancel);
            if(r == DialogResult.OK)
            {
                string tno = dataGridView1.SelectedCells[0].Value.ToString();
                string tname = dataGridView1.SelectedCells[2].Value.ToString();
                string sql = "delete from teacher where tno='" + tno + "' and tname='" + tname + "'";
                DB db = new DB();
                int i = db.Execute(sql);
                if(i>0)
                {
                    MessageBox.Show("删除成功");
                }             
                Table();
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
