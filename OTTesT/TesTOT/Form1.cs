using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesTOT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            statusStrip1.Items[0].Text = "Дата : " + DateTime.Now.ToLongDateString();
            statusStrip1.Items[1].Text = "  Время : " + DateTime.Now.ToLongTimeString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы желаете продолжить и перейти к выполнению теста?", "Оповещение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string path = @"C:\Users\Public\TestResult\";
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                using (FileStream fileStream = new FileStream(path + (textBox1.Text + textBox2.Text) + ".txt", FileMode.Append))
                {
                    using (StreamWriter streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.WriteLine(textBox1.Text + " " + textBox2.Text);
                    }
                }
                Form2 form2 = new Form2();
                form2.Show();
                this.Hide();
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox1.Text, @"[\d\W\s]+"))
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
                textBox1.SelectionStart = textBox1.TextLength;
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox2.Text, @"[\d\W\s]+"))
            {
                textBox2.Text = textBox2.Text.Remove(textBox2.Text.Length - 1);
                textBox2.SelectionStart = textBox2.TextLength;
            }
        }
    }
}
