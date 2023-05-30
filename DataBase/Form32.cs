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
    public partial class Form32 : Form
    {
        string Sno;
        public Form32()
        {
            InitializeComponent();
        }

        public Form32(string sno)
        {
            InitializeComponent();
            Sno = sno;
            string sql = "select * from student where sno='" + Sno + "'";
            DB db = new DB();
            IDataReader dr = db.read(sql);
            dr.Read();
            textBox1.Text = dr["scode"].ToString();
            dr.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = "update student set scode='" + textBox2.Text + "' where sno='" + Sno + "'";
            DB db = new DB();
            int i = db.Execute(sql);
            if(i>0)
            {
                MessageBox.Show("修改成功");
            }
        }

        private void Form32_Load(object sender, EventArgs e)
        {

        }
    }
}
