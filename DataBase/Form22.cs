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
    public partial class Form22 : Form
    {
        public Form22()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if(textBox5.Text == "基础必修")
                {
                    double GPA;
                    double credit = Convert.ToDouble(textBox6.Text.ToString());
                    double grade = Convert.ToDouble(textBox7.Text.ToString());
                    if (grade==100)
                    {
                        GPA = 5.0;
                    }
                    else if (grade >= 90 && grade <100)
                    {
                        GPA = 4.0;
                    }
                    else if (grade >= 85 && grade <= 89)
                    {
                        GPA = 3.7;
                    }
                    else if (grade >= 82 && grade <= 84)
                    {
                        GPA = 3.3;
                    }
                    else if (grade >= 78 && grade <= 81)
                    {
                        GPA = 3.0;
                    }
                    else if (grade >= 75 && grade <= 77)
                    {
                        GPA = 2.7;
                    }
                    else if (grade >= 71 && grade <= 74)
                    {
                        GPA = 2.3;
                    }
                    else if (grade >= 66 && grade <= 70)
                    {
                        GPA = 2.0;
                    }
                    else if (grade >= 62 && grade <= 65)
                    {
                        GPA = 1.7;
                    }
                    else if (grade >= 60 && grade <= 61)
                    {
                        GPA = 1.3;
                    }
                    else
                    {
                        GPA = 0;
                    }
                    string sql = "Insert into elect values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','"+GPA*1.2+"','"+GPA+"','"+credit*GPA*1.2+"')";
                    DB db = new DB();
                    int i = db.Execute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("保存成功");
                        textBox1.Text = null;
                        textBox2.Text = null;
                        textBox3.Text = null;
                        textBox4.Text = null;
                        textBox5.Text = null;
                        textBox6.Text = null;
                        textBox7.Text = null;
                    }
                }
                else if (textBox5.Text == "专业必修")
                {
                    double GPA;
                    double credit = Convert.ToDouble(textBox6.Text.ToString());
                    double grade = Convert.ToDouble(textBox7.Text.ToString());
                    if (grade == 100)
                    {
                        GPA = 5.0;
                    }
                    else if (grade >= 90 && grade < 100)
                    {
                        GPA = 4.0;
                    }
                    else if (grade >= 85 && grade <= 89)
                    {
                        GPA = 3.7;
                    }
                    else if (grade >= 82 && grade <= 84)
                    {
                        GPA = 3.3;
                    }
                    else if (grade >= 78 && grade <= 81)
                    {
                        GPA = 3.0;
                    }
                    else if (grade >= 75 && grade <= 77)
                    {
                        GPA = 2.7;
                    }
                    else if (grade >= 71 && grade <= 74)
                    {
                        GPA = 2.3;
                    }
                    else if (grade >= 66 && grade <= 70)
                    {
                        GPA = 2.0;
                    }
                    else if (grade >= 62 && grade <= 65)
                    {
                        GPA = 1.7;
                    }
                    else if (grade >= 60 && grade <= 61)
                    {
                        GPA = 1.3;
                    }
                    else
                    {
                        GPA = 0;
                    }
                    string sql = "Insert into elect values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + GPA * 1.2 + "','" + GPA + "','" + credit * GPA * 1.1 + "')";
                    DB db = new DB();
                    int i = db.Execute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("保存成功");
                        textBox1.Text = null;
                        textBox2.Text = null;
                        textBox3.Text = null;
                        textBox4.Text = null;
                        textBox5.Text = null;
                        textBox6.Text = null;
                        textBox7.Text = null;
                    }
                }
                else if (textBox5.Text == "选修")
                {
                    double GPA;
                    double credit = Convert.ToDouble(textBox6.Text.ToString());
                    double grade = Convert.ToDouble(textBox7.Text.ToString());
                    if (grade == 100)
                    {
                        GPA = 5.0;
                    }
                    else if (grade >= 90 && grade < 100)
                    {
                        GPA = 4.0;
                    }
                    else if (grade >= 85 && grade <= 89)
                    {
                        GPA = 3.7;
                    }
                    else if (grade >= 82 && grade <= 84)
                    {
                        GPA = 3.3;
                    }
                    else if (grade >= 78 && grade <= 81)
                    {
                        GPA = 3.0;
                    }
                    else if (grade >= 75 && grade <= 77)
                    {
                        GPA = 2.7;
                    }
                    else if (grade >= 71 && grade <= 74)
                    {
                        GPA = 2.3;
                    }
                    else if (grade >= 66 && grade <= 70)
                    {
                        GPA = 2.0;
                    }
                    else if (grade >= 62 && grade <= 65)
                    {
                        GPA = 1.7;
                    }
                    else if (grade >= 60 && grade <= 61)
                    {
                        GPA = 1.3;
                    }
                    else
                    {
                        GPA = 0;
                    }
                    string sql = "Insert into elect values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + GPA * 1.2 + "','" + GPA + "','" + credit * GPA * 1.0 + "')";
                    DB db = new DB();
                    int i = db.Execute(sql);
                    if (i > 0)
                    {
                        MessageBox.Show("保存成功");
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
        }
    }
}
