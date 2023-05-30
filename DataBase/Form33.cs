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
    public partial class Form33 : Form
    {
        string Sno;
        public Form33(string sno)
        {
            Sno = sno;
            InitializeComponent();
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select* from elect where sno='" + Sno + "'";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string cno = dr["cno"].ToString();
                string sql2 = "select* from elect where cno='" + cno + "'";
                IDataReader dr2 = db.read(sql2);
                dr2.Read();
                string a, b, c, d, e, f, g, h, i;
                a = dr2["sno"].ToString();
                b = dr2["sname"].ToString();
                c = dr2["cno"].ToString();
                d = dr2["cname"].ToString();
                e = dr2["ctype"].ToString();
                f = dr2["ccredit"].ToString();
                g = dr2["grade"].ToString();
                h = dr2["cGPA"].ToString();
                i = dr2["GPA"].ToString();
                string[] str = { a, b, c, d, e, f, g, h, i };
                dataGridView1.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();//关闭连接
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "select sum(ccredit) from elect where sno='" + Sno + "'";
            DB db = new DB();
            IDataReader dr1 = db.read(sql);
            dr1.Read();
            string a;
            a = dr1[""].ToString();
            MessageBox.Show(a);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sql = "select sum(ccGPA) from elect where sno='" + Sno + "'";
            DB db = new DB();
            IDataReader dr1 = db.read(sql);
            dr1.Read();
            string a;
            a = dr1[""].ToString();
            MessageBox.Show(a);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //读取a的值，为13
            string sql = "select sum(ccredit) from elect where sno='"+Sno+"'";
            DB db = new DB();
            IDataReader dr1 = db.read(sql);
            dr1.Read();
            string sumCredit;
            sumCredit = dr1[""].ToString();
            //读取b的值，为53.5
            string sq2 = "select sum(ccGPA) from elect where sno='" + Sno + "'";
            IDataReader dr2 = db.read(sq2);
            dr2.Read();
            string sumCcGPA;
            sumCcGPA = dr2[""].ToString();
            float ccredit = float.Parse(sumCredit);
            float ccGPA = float.Parse(sumCcGPA);
            float avgGPA = ccGPA / ccredit;
            string result = Convert.ToString(avgGPA);
            MessageBox.Show(result);
        }

        private void Form33_Load(object sender, EventArgs e)
        {

        }
    }
}
