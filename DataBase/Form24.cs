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
    public partial class Form24 : Form
    {
        public Form24()
        {
            InitializeComponent();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select sno,sname,sum(ccGPA)/sum(ccredit) from elect group by sname,sno order by sum(ccGPA)/ sum(ccredit) DESC; ";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c;
                a = dr["sno"].ToString();
                b = dr["sname"].ToString();
                c = dr[""].ToString();
                string[] str = { a, b, c};
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        public void TableSclass()
        {
            dataGridView1.Rows.Clear();
            string sql = "select elect.sno,elect.sname,sum(ccGPA)/sum(ccredit) from elect, student where student.sno = elect.sno and student.sclass = '"+textBox1.Text+"' group by elect.sname,elect.sno order by sum(ccGPA)/ sum(ccredit) DESC; ";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c;
                a = dr["sno"].ToString();
                b = dr["sname"].ToString();
                c = dr[""].ToString();
                string[] str = { a, b, c };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TableSclass();
        }
    }
}
