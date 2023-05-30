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
    public partial class Form21 : Form
    {
        string[] str = new string[7];
        public Form21()
        {
            InitializeComponent();
            button3.Visible = false;//插入时隐藏修改按钮
        }

        public Form21(string[] a)
        {
            InitializeComponent();
            for(int i=0; i<7; i++)
            {
                str[i] = a[i];
            }
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            textBox4.Text = str[3];
            textBox5.Text = str[4];
            textBox6.Text = str[5];
            textBox7.Text = str[6];
            button1.Visible = false;//修改时隐藏保存按钮
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text==""|| textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                string sql = "Insert into student values('"+textBox1.Text+"','123456','"+textBox2.Text+"','"+textBox3.Text+"','"+textBox4.Text+"','"+textBox5.Text+"','"+textBox6.Text+"','"+textBox7.Text+"')";
                DB db = new DB();
                int i = db.Execute(sql);
                if(i > 0)
                {
                    MessageBox.Show("插入成功");
                    textBox1.Text = null;
                    textBox2.Text = null;
                    textBox3.Text = null;
                    textBox4.Text = null;
                    textBox5.Text = null;
                    textBox6.Text = null;
                    textBox7.Text = null;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
            textBox4.Text = null;
            textBox5.Text = null;
            textBox6.Text = null;
            textBox7.Text = null;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("修改后有空项，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(textBox1.Text != str[0])
                {
                    string sql ="update student set sno='"+textBox1.Text+"' where sno='"+str[0]+"' and sname='"+str[1]+"'";
                    DB db = new DB();
                    db.Execute(sql);
                    str[0] = textBox1.Text;
                }
                if (textBox2.Text != str[1])
                {
                    string sql = "update student set sname='" + textBox2.Text + "' where sno='" + str[0] + "' and sname='" + str[1] + "'";
                    DB db = new DB();
                    db.Execute(sql);
                    str[1] = textBox2.Text;
                }
                if (textBox3.Text != str[2])
                {
                    string sql = "update student set ssex='" + textBox3.Text + "' where sno='" + str[0] + "' and sname='" + str[1] + "'";
                    DB db = new DB();
                    db.Execute(sql);
                    str[2] = textBox3.Text;
                }
                if (textBox4.Text != str[3])
                {
                    string sql = "update student set sbirth='" + textBox4.Text + "' where sno='" + str[0] + "' and sname='" + str[1] + "'";
                    DB db = new DB();
                    db.Execute(sql);
                    str[3] = textBox4.Text;
                }
                if (textBox5.Text != str[4])
                {
                    string sql = "update student set sclass='" + textBox5.Text + "' where sno='" + str[0] + "' and sname='" + str[1] + "'";
                    DB db = new DB();
                    db.Execute(sql);
                    str[4] = textBox5.Text;
                }
                if (textBox6.Text != str[5])
                {
                    string sql = "update student set scourse='" + textBox6.Text + "' where sno='" + str[0] + "' and sname='" + str[1] + "'";
                    DB db = new DB();
                    db.Execute(sql);
                    str[5] = textBox6.Text;
                }
                if (textBox7.Text != str[6])
                {
                    string sql = "update student set sdepartment='" + textBox7.Text + "' where sno='" + str[0] + "' and sname='" + str[1] + "'";
                    DB db = new DB();
                    db.Execute(sql);
                    str[6] = textBox7.Text;
                }
            }
        }
    }
}
