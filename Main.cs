using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Money
{
    delegate int Check_Emptyd(); //委托
    public partial class Main : Form
    {

        int index = 0;
        List<string> write = new List<string>();

        public Main()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Check_Emptyd ce = new Check_Emptyd(Check_Empty);
            int zt = ce.Invoke(); //委托
            if (zt == 0)
            {
                index++;
                //记录
                try
                {
                    if (index < 10)
                    {
                        listBox1.Items.Add(index.ToString() + "                " + textBox1.Text + "             " + textBox2.Text + "                 " + textBox3.Text + "                " + (Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text)).ToString());
                    }
                    else
                    {
                        listBox1.Items.Add(index.ToString() + "               " + textBox1.Text + "             " + textBox2.Text + "                 " + textBox3.Text + "                " + (Convert.ToInt32(textBox2.Text) * Convert.ToInt32(textBox3.Text)).ToString());
                    }
                }
                catch
                {
                    //无法计算总价
                    MessageBox.Show("单价或数量填写错误！","ToysWorld",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    index --;
                }
            }
        }
        public int Check_Empty()
        {
            if (textBox1.Text == string.Empty) {
                MessageBox.Show("请填写品名!");
                return 2;
            }
            if (textBox2.Text == string.Empty)
            {
                MessageBox.Show("请填写单价!");
                return 2;
            }
            if (textBox3.Text == string.Empty)
            {
                MessageBox.Show("请填写数量!");
                return 2;
            }
            return 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            index--;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string local = Application.StartupPath;
            StreamWriter sw = new StreamWriter(local + "\\今日销售记录.txt");
            
            write.Add("序号              品名              单价              数量              总价");
            sw.Write("序号              品名              单价              数量              总价 \n");
            sw.Flush();
            for (int i = 0; i < listBox1.Items.Count ; i++)
            {
                write.Add(listBox1.Items[i].ToString());
                sw.Write(listBox1.Items[i].ToString() + "\n");
                //把缓冲区写入基础流，虽然我也不知道为什么要这么干^_^...
                sw.Flush();
            }
            sw.Close(); //不关文件后果很严重
            MessageBox.Show("已经存储至" + local + "\\今日销售记录.txt","ToysWorld",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);

        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Vip vip = new Vip();
            vip.Show();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
