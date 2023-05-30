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
    public partial class Form34 : Form
    {
        string Sno;
        public Form34(string sno) 
        {
            InitializeComponent();
            Sno = sno;
            Table();
        }

        public void Table()
        {
            dataGridView1.Rows.Clear();
            string sql = "select * from student where sno='"+Sno+"' ";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string a, b, c, d, e, f, g, h;
                a = dr["sno"].ToString();
                b = dr["scode"].ToString();
                c = dr["sname"].ToString();
                d = dr["ssex"].ToString();
                e = dr["sbirth"].ToString();
                f = dr["sclass"].ToString();
                g = dr["scourse"].ToString();
                h = dr["sdepartment"].ToString();
                string[] str = { a, b, c, d, e, f, g ,h };
                dataGridView1.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form35 f = new Form35();
            f.Show();
        }

        private void Form34_Load(object sender, EventArgs e)
        {

        }
    }
}
