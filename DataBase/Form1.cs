using System.Data;

namespace DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //取消按钮
        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = null;
            textBox2.Text = null;
            comboBox1.Text = null;
        }
        //确认按钮
        private void button1_Click(object sender, EventArgs e)
        {
            if (login())
            {
                timer1.Start();
                textBox1.Visible = false;
                textBox2.Visible = false;
                comboBox1.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                label1.Visible = false;
                label2.Visible = false;
                label3.Visible = false;
            }
        }
        //判断用户名、密码、权限
        private bool login()
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("输入不完整，请检查", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            switch (comboBox1.Text)
            {
                case "学生":
                    {
                        string sql = "select *from student where sno = '" + textBox1.Text + "' and scode = '" + textBox2.Text + "'";
                        DB db = new DB();
                        IDataReader dr = db.read(sql);
                        if (dr.Read())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误");
                            return false;
                        }
                    }
                case "教师":
                    {
                        string sql = "select *from teacher where tno = '" + textBox1.Text + "' and tcode = '" + textBox2.Text + "'";
                        DB db = new DB();
                        IDataReader dr = db.read(sql);
                        if (dr.Read())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误");
                            return false;
                        }
                    }
                case "管理员":
                    {
                        string sql = "select* from manager where mno='" + textBox1.Text + "' and mcode='" + textBox2.Text + "'";
                        DB dB = new DB();
                        IDataReader dr = dB.read(sql);
                        if (dr.Read())
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误");
                            return false;
                        }
                    }
            }
            return false;
        }
        //登录状态
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Location.X < 180)
            {
                pictureBox1.Location = new Point(pictureBox1.Location.X + 1, pictureBox1.Location.Y);
            }
            else
            {
                if (comboBox1.Text == "学生")
                {
                    string sql = "select * from student where sno = '" + textBox1.Text + "' and scode = '" + textBox2.Text + "'";
                    DB dB = new DB();
                    IDataReader dr = dB.read(sql);
                    dr.Read();
                    string sno = dr["sno"].ToString();
                    Form3 form3 = new Form3(sno);
                    form3.Show();
                    this.Hide();
                }
                else if (comboBox1.Text == "教师")
                {
                    string sql = "select * from teacher where tno = '" + textBox1.Text + "' and tcode = '" + textBox2.Text + "'";
                    DB dB = new DB();
                    IDataReader dr = dB.read(sql);
                    dr.Read();
                    string tno = dr["tno"].ToString();
                    Form2 form2 = new Form2(tno);
                    form2.Show();
                    this.Hide();
                }
                else if (comboBox1.Text == "管理员")
                {
                    Form4 form4 = new Form4();
                    form4.Show();
                    this.Hide();
                }

                timer1.Stop();
            }
        }
    }
}