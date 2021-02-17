using System;
using System.Windows.Forms;
using System.IO;

namespace Money
{
    public partial class Vip : Form
    {
        public Vip()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string local = Application.StartupPath;
            StreamWriter sr = new StreamWriter(local + "\\temp\\vip.txt",true);
            sr.WriteLine(textBox1.Text + ":" + "0");
            sr.Flush();
            sr.Close();
            MessageBox.Show("已发卡,卡号" + textBox1.Text + ",余额0.00元。","会员卡系统",MessageBoxButtons.OK,MessageBoxIcon.Information);
            int temp = Convert.ToInt32(textBox1.Text);
            temp++;
            textBox1.Text = temp.ToString();
        }
    }
}
