using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Message_Security
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label1.BackColor = System.Drawing.Color.Transparent;
            label2.BackColor = System.Drawing.Color.Transparent;
            label3.BackColor = System.Drawing.Color.Transparent;
            if (Option.ForeColor == Color.Black) Option.ForeColor = Color.White;
        }

        bool kt = true;

        private void button1_Click(object sender, EventArgs e)
        {
            string key = textBox1.Text;
            string message = textBox2.Text;
            if (message == "") MessageBox.Show("Vui lòng nhập văn bản vào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            int s = 0; 
            for (int i=0;i<key.Length;i++) s += (int)key[i];
            s %= 94 - 46;
            string messageSecurity=""; 
            if (kt)
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int k = (int)message[i];
                    k += s;
                    if (k < 32)
                    {
                        int t = 32 - k;
                        k = 127 - t;
                    }
                    else if (k > 126)
                    {
                        int t = k - 126;
                        k = 31 + t;
                    }
                    char ch = (char)(k);
                    messageSecurity += ch;
                }
                textBox3.Text = messageSecurity;
            }
            else
            {
                for (int i = 0; i < message.Length; i++)
                {
                    int k = (int)message[i];
                    k -= s;
                    if (k < 32)
                    {
                        int t = 32 - k;
                        k = 127 - t;
                    }
                    else if (k > 126)
                    {
                        int t = k - 126;
                        k = 31 + t;
                    }
                    char ch = (char)(k);
                    messageSecurity += ch;
                }
                textBox3.Text = messageSecurity;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";
            textBox3.Text = "";
            if (kt)
            {
                button1.Text = "Giải Hóa";
                button3.Text = "Chuyển Sang Mã Hóa";
                label2.Text = ":Tin Nhắn Đã Mã Hóa";
                label3.Text = ":Tin Nhắn Đã Giải Hóa";
            }
            else
            {
                button1.Text = "Mã Hóa";
                button3.Text = "Chuyển Sang Dịch";
                label2.Text = ":Tin Nhắn Cần Mã Hóa";
                label3.Text = ":Tin Nhắn Đã Mã Hóa";
            }    
            kt = !kt;
        }

        private void backGroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                string fileName = dlg.FileName;
                Image myImage = new Bitmap(fileName);
                this.BackgroundImage = myImage;
            }    
        }

        private void colorTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog()==DialogResult.OK)
            {
                string str = dlg.Color.Name;
                label1.ForeColor = dlg.Color;
                label2.ForeColor = dlg.Color;
                label3.ForeColor = dlg.Color;
            }    
        }

        private void textcolorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string str = dlg.Color.Name;
                textBox1.ForeColor = dlg.Color;
                textBox2.ForeColor = dlg.Color;
                textBox3.ForeColor = dlg.Color;
            }
        }

        bool optionColor = true;
        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (optionColor) Option.ForeColor = Color.Black;
            else Option.ForeColor=Color.White;
            optionColor = !optionColor;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            Option.ForeColor = Color.White;
            optionColor = true;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Phiên bản: 1.0\nĐây là ứng dụng dùng để mã hóa tin nhắn\nĐược thiết kế bởi Trần Ngọc Tiến", "About", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VietSub(ref string str)
        {
            if (str == "â") str = "aa";
            else if (str == "Â") str = "AA";
            else if (str == "ă") str = "aw";
            else if (str == "Ă") str = "AW";
        }    

        private void ChangeText(ref string str)
        {
            string text = "";
            for (int i = 0; i < str.Length; i++)
                text += str[i];
            str = text;
        }
    }
}
