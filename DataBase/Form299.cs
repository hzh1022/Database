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
    public partial class Form299 : Form
    {
        string Tno;
        public Form299(string tno)
        {
            Tno = tno;
            InitializeComponent();
            Table();
        }

        public void Table()
        {
            dataGridView2.Rows.Clear();
            string sql = "select* from teacher where tno='"+Tno+"' ";
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
                dataGridView2.Rows.Add(str);
            }
            dr.Close();//关闭连接
        }

        private void Form299_Load(object sender, EventArgs e)
        {

        }
    }
}
