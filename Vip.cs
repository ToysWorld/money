using System;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;

namespace Money
{
    public partial class Vip : Form
    {
        string local = Application.StartupPath;

        List<string> vip = new List<string>();
        int vip_count;


        public Vip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {    
            give_card();
            add_card();

        }

        private void Vip_Load(object sender, EventArgs e)
        {
            #region 读取卡片文件
            //看样子是没删干净
            StreamReader sr2 = new StreamReader(local + "\\temp\\vipcount.txt");
            vip_count = Convert.ToInt32(sr2.ReadLine());
            MessageBox.Show(vip_count.ToString());
            sr2.Close();
            int start = Convert.ToInt32(textBox1.Text);
            start = start + vip_count;
            textBox1.Text = start.ToString();
            textBox2.Text = start.ToString();
            string localhost = local + "\\temp\\vip.txt";
            MessageBox.Show(localhost);
            StreamReader sr3 = new StreamReader(localhost,System.Text.Encoding.UTF8);
            MessageBox.Show(localhost);
            string path = sr3.ReadToEnd();
            for (int i = 0; i <vip_count;i++)
            {
                //按行隔开
                vip.Add(path.Split('|')[i]);
                MessageBox.Show(path.Split('|')[i]);

            }
            sr3.Close();

            #endregion
        }

        public void give_card()
        {
            #region 发新卡
            StreamWriter sr = new StreamWriter(Application.StartupPath + "\\temp\\vip.txt", true);
            sr.WriteLine(textBox1.Text + ":" + "0");
            sr.Flush();
            sr.Close();
            MessageBox.Show("已发卡,卡号" + textBox1.Text + ",余额0.00元。", "会员卡系统", MessageBoxButtons.OK, MessageBoxIcon.Information);
            int temp = Convert.ToInt32(textBox1.Text);
            temp++;
            textBox1.Text = temp.ToString();

            #endregion
        }
        public void add_card()
        {
            #region 记录卡片信息
            StreamReader sr = new StreamReader(local + "\\temp\\vipcount.txt");
            int count = Convert.ToInt32(sr.ReadLine());
            sr.Close();
            count++;
            StreamWriter sw = new StreamWriter(local + "\\temp\\vipcount.txt");
            sw.Write(count.ToString());
            sw.Flush();
            sw.Close();
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        public void read_card()
        {
            #region 解析卡片信息
            int index = Convert.ToInt32(textBox2.Text) - 1000100001 - 1; //索引从0开始
            for (int i = 0; i < vip_count; i++)
            {
                string str = vip[i];
                string[] result = str.Split(':');
                string money = result[1];
                MessageBox.Show(money);

            }

            #endregion
        }

    }
}