using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Money;
using System.Threading;

namespace Money
{
    public partial class Form1 : Form
    {
        public int login_count; //登陆次数
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region 读账号
            string path = Application.StartupPath;
            StreamReader sr = new StreamReader(path + "\\temp\\account.txt");
            List<string> account = new List<string>(); //差点忘了起名了:(
            //读两次，有且只有一个账号
            string line = sr.ReadLine();
            account.Add(line);
            line = sr.ReadLine();
            account.Add(line);
            #endregion
            if (textBox1.Text == account[0] && textBox2.Text == account[1]){
                MessageBox.Show("登录成功");
                login_count = 0;
                Main mi = new Money.Main();
                mi.Show();
                //加载窗体
            }
            else
            {
                MessageBox.Show("用户名或密码错误,您还有" + (3 - login_count - 1).ToString()+ "次尝试机会");
                login_count++;
                check_count(login_count);
            }

        }

        public static void check_count(int login_count)
        {
            //拒绝非法登录
            if (login_count > 2)
            {
                MessageBox.Show("禁止非法登录","ToysWorld",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Environment.Exit(1);
            }
        }
    }
}
