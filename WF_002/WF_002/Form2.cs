using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_002
{
    public partial class Form2 : Form
    {
        private int MSSV;
        public delegate void ReloadGridViewForm1();
        public ReloadGridViewForm1 ReloadForm1;
        public Form2(int MSSV = -1)
        {
            InitializeComponent();
            createComboboxLopSH();
            this.MSSV = MSSV;
            RenderView();
        }

        private void createComboboxLopSH()
        {
            foreach (LopSH lopSH in CSDL_OOP.Instance.GetAllLopSH())
            {
                this.cbbLopSH.Items.Add(new MapCbbTenLopSH(lopSH.Ten, lopSH.Id));
            }
            this.cbbLopSH.SelectedIndex = 0;
        }

        private void RenderView()
        {
            SV sv = CSDL_OOP.Instance.FindSVByMSSV(this.MSSV);

            if (sv != null)
            {
                this.txtMSSV.Text = sv.MSSV.ToString();
                this.txtTen.Text = sv.Ten;

                foreach(MapCbbTenLopSH item in this.cbbLopSH.Items)
                {
                    if (item.idLopSH == sv.LopSHId)
                    {
                        this.cbbLopSH.SelectedItem = item;
                    }
                }

                this.dtpNgaySinh.Value = sv.NgaySinh;
                
                if (sv.GioiTinh)
                {
                    this.rbNam.Checked = true;
                } else
                {
                    this.rbNu.Checked = true;
                }
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            int mssv;

            // add new SV
            if (MSSV == -1)
            {
                mssv = CSDL_OOP.GenerateId();
            }
            else
            {
                // edit SV
                mssv = this.MSSV;
            }

            string ten = this.txtTen.Text.Trim();
            bool gioiTinh = this.rbNam.Checked;
            DateTime ngaySinh = this.dtpNgaySinh.Value;
            int idLop = Convert.ToInt32(((MapCbbTenLopSH)this.cbbLopSH.SelectedItem).idLopSH);

            // validate
            if (ten == "" || ten == null)
            {
                MessageBox.Show("Ten khong duoc de trong");
                return;
            }

            // create new instance
            SV sv = new SV(mssv, ten, gioiTinh, ngaySinh, idLop);

            // save or update
            CSDL_OOP.Instance.SaveSV(sv);

            // reload form 1
            this.ReloadForm1();

            this.Dispose();
        }
        
    }
}
