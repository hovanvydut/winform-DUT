using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalPaymentApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.combobox_tramrang.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.textbox_tenkhachhang.Text == "")
            {
                MessageBox.Show("Tên khách hàng trống");
                return;
            }
                

            this.total.Text = calcMoney().ToString();
        }

        private double calcMoney()
        {
            double total = 0;

            if (this.checkbox_caovoi.Checked)
                total += 100;

            if (this.checkbox_taytrang.Checked)
                total += 1200;

            if (this.checkbox_chuphinhrang.Checked)
                total += 200;

            try
            {
                string select = this.combobox_tramrang.SelectedItem.ToString();
                int quantity = Convert.ToInt32(select);
                total += quantity * 80;
            } catch (FormatException e)
            {
                MessageBox.Show("Định dạng số lượng trám răng không đúng");
                return 0;
            }

            return total;
        }

    }
}
