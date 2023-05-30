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
    public partial class Form23 : Form
    {
        public Form23()
        {
            InitializeComponent();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from elect";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h, i, j;
                a = dr["sno"].ToString();
                b = dr["sname"].ToString();
                c = dr["cno"].ToString();
                d = dr["cname"].ToString();
                e = dr["ctype"].ToString();
                g = dr["ccredit"].ToString();
                h = dr["grade"].ToString();
                i = dr["cGPA"].ToString();
                j = dr["GPA"].ToString();
                string[] str = { a, b, c, d, e, g ,h ,i ,j };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        public void TableSdepartment()
        { 
            dataGridView1.Rows.Clear();
            string sql = "select elect.sno,elect.sname,elect.cno,elect.cname,elect.ctype,elect.ccredit,elect.grade,elect.cGPA,elect.GPA from student, elect where student.sno = elect.sno and student.sdepartment = '"+textBox1.Text+"'; ";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h, i, j;
                a = dr["sno"].ToString();
                b = dr["sname"].ToString();
                c = dr["cno"].ToString();
                d = dr["cname"].ToString();
                e = dr["ctype"].ToString();
                g = dr["ccredit"].ToString();
                h = dr["grade"].ToString();
                i = dr["cGPA"].ToString();
                j = dr["GPA"].ToString();
                string[] str = { a, b, c, d, e, g, h, i, j };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        public void TableSclass()
        {
            dataGridView1.Rows.Clear();
            string sql = "select elect.sno,elect.sname,elect.cno,elect.cname,elect.ctype,elect.ccredit,elect.grade,elect.cGPA,elect.GPA from student, elect where student.sno = elect.sno and student.sclass = '" + textBox2.Text + "'; ";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, g, h, i, j;
                a = dr["sno"].ToString();
                b = dr["sname"].ToString();
                c = dr["cno"].ToString();
                d = dr["cname"].ToString();
                e = dr["ctype"].ToString();
                g = dr["ccredit"].ToString();
                h = dr["grade"].ToString();
                i = dr["cGPA"].ToString();
                j = dr["GPA"].ToString();
                string[] str = { a, b, c, d, e, g, h, i, j };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void 取消该行成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string sno = dataGridView1.SelectedCells[0].Value.ToString();
            string cno = dataGridView1.SelectedCells[2].Value.ToString();
            string sql = "delete elect where sno='" + sno + "' and cno='" + cno + "'";
            DB db = new DB();
            db.Execute(sql);
            Table();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableSdepartment();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Table();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            TableSclass();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Table();
        }
    }
}
