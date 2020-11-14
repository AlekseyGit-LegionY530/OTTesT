using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TesTOT
{
    public partial class Form4 : Form
    {
        private string path = @"C:\Users\Public\TestResult\";
        public Form4()
        {
            InitializeComponent();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            using (FileStream file = new FileStream(path + listBox1.SelectedItem.ToString(), FileMode.Open))
            {
                string line = string.Empty;
                using (StreamReader streamReader = new StreamReader(file))
                {
                    while ((line = streamReader.ReadLine()) != null)
                    {
                        listBox2.Items.Add(line);
                    }
                }
            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {
            foreach (string key in Directory.GetFiles(path))
            {
                string[] arr = key.ToString().Split('\\');
                listBox1.Items.Add(arr[arr.Length - 1]);
            }
        }
        private void Form4_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        private void регистрацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Хотите закрыть программу?", "Оповещение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
