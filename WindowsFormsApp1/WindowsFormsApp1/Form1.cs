using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string data = this.textBox1.Text;

            if (this.comboBox1.Items.Contains(data))
            {
                MessageBox.Show("Trung du lieu trong list box");
            } else
            {
                this.comboBox1.Items.Add(data);
                this.textBox1.Text = "";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idx = this.comboBox1.SelectedIndex;
            string txt = this.comboBox1.Items[idx].ToString();
            this.textBox1.Text = txt;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.checkBox1.Checked.ToString());
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show(this.radioButton1.Checked.ToString());
        }
    }
}
