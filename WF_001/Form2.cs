using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_001
{
    public partial class Form2 : Form
    {
        public delegate void PointToForm1(SV sv);
        public PointToForm1 pointToForm1;
        public SV currentSV { get; private set; }
        public Form2()
        {
            InitializeComponent();
            createComboboxLopSH();
        }

        public void SetCurrentSVAndUpdateView(SV sv, bool isEdit)
        {
            setCurrentSv(sv);

            if (isEdit)
                updateView();
            else
                AddView();
        }

        private void AddView()
        {

        }

        private void setCurrentSv(SV sv)
        {
            this.currentSV = sv;
        }

        private void updateView()
        {
            this.txtMSSV.Text = this.currentSV.MSSV;
            this.txtTen.Text = this.currentSV.Ten;
            this.dtpNgaySinh.Value = this.currentSV.NgaySinh;

            if (this.currentSV.GioiTinh)
            {
                this.rbNam.Checked = true;
            } else
            {
                this.rbNu.Checked = true;
            }

            int idx = 0;
            foreach (CBBItemTenLopSH item in this.cbbLopSH.Items)
            {
                if (item.value == this.currentSV.lopSh.Id)
                {
                    this.cbbLopSH.SelectedIndex = idx;
                }
                idx++;
            }
        }

        private void createComboboxLopSH()
        {
            DataRowCollection r = CSDL.Instance.dtLopSH.Rows;

            foreach (DataRow dr in r)
            {
                int value = (int)dr["Id"];
                string text = (string)dr["Ten"];

                this.cbbLopSH.Items.Add(new CBBItemTenLopSH(value, text));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (getTxtTen() == null || getTxtTen().Equals(""))
            {
                MessageBox.Show("Vui long nhap ten");
                return;
            }
            this.currentSV.Ten = getTxtTen();

            this.currentSV.NgaySinh = getDtpNgaySinh();

            this.currentSV.GioiTinh = getRbGioiTinh();

            if (getCbbLopSH() == null)
            {
                MessageBox.Show("Vui long chon lop");
                return;
            }
            this.currentSV.lopSh = getCbbLopSH();

            SV sv;
            if (this.currentSV.MSSV == null)
                sv = new SV(CSDL.Instance.GenerateIdForSV(), this.currentSV);
            else
                sv = new SV(this.currentSV);

            this.pointToForm1(sv);
            this.Dispose();
        }

        public string getTxtMSSV()
        {
            return this.txtMSSV.Text;
        }

        public string getTxtTen()
        {
            return this.txtTen.Text;
        }

        public DateTime getDtpNgaySinh()
        {
            return this.dtpNgaySinh.Value;
        }

        public bool getRbGioiTinh()
        {
            if (this.rbNam.Checked)
                return true;

            return false;
        }

        public LopSH getCbbLopSH()
        {
            int idx = this.cbbLopSH.SelectedIndex;

            if (idx == -1)
                return null;

            int idLopSH = ((CBBItemTenLopSH)this.cbbLopSH.Items[idx]).value;
            return CSDL.Instance.GetLopSHById(idLopSH);
        }
    }
}
