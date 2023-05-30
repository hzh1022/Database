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
    public partial class Form31 : Form
    {
        string Sno;
        public Form31(string sno)
        {
            Sno = sno;
            InitializeComponent();
            Table();
        }

        public void Table()
        {
            dataGridView2.Rows.Clear();
            string sql = "select* from courseRecord where sno='"+Sno+"'";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            while (dr.Read())
            {
                string cno = dr["cno"].ToString();
                string sql2 = "select* from course where cno='" + cno + "'";
                IDataReader dr2 = db.read(sql2);
                dr2.Read();
                string a, b, c, d, e, f, g, h, i;
                a = dr2["cno"].ToString();
                b = dr2["cname"].ToString();
                c = dr2["ctype"].ToString();
                d = dr2["csize"].ToString();
                e = dr2["ccredit"].ToString();
                f = dr2["cteacher"].ToString();
                g = dr2["ctime"].ToString();
                h = dr2["croom"].ToString();
                i = dr2["cdepartment"].ToString();
                string[] str = { a, b, c, d, e, f, g, h, i };
                dataGridView2.Rows.Add(str);
                dr2.Close();
            }
            dr.Close();//关闭连接
        }

        private void Form31_Load(object sender, EventArgs e)
        {

        }

        private void 取消这门课程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string cno = dataGridView2.SelectedCells[0].Value.ToString();
            string sql = "delete sc where sno='" + Sno + "' and cno='" + cno + "'";
            DB db = new DB();
            db.Execute(sql);
            Table();
        }
    }
}
