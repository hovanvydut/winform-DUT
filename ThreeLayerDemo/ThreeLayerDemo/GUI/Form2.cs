using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreeLayerDemo.DTO;
using ThreeLayerDemo.BLL;

namespace ThreeLayerDemo.GUI
{
    public partial class Form2 : Form
    {
        public delegate void PointToForm1();
        public PointToForm1 ReloadViewForm1 { get; set; }
        private int MSSV;
        public Form2(int MSSV = -1)
        {
            InitializeComponent();
            CreateCbbLopSH();

            this.MSSV = MSSV;
            RenderView();
        }


        private void RenderView()
        {
            // Edit mode
            if (this.MSSV != -1)
            {
                SV sv = BLL_QLSV.Instance.GetSVByMSSV(this.MSSV);
                this.txtMSSV.Text = sv.MSSV.ToString();
                this.txtTen.Text = sv.NameSV;
                
                foreach (CBBItem item in this.cbbLopSH.Items)
                {
                    if (item.value.Equals(sv.ID_Lop.ToString()))
                    {
                        this.cbbLopSH.SelectedItem = item;
                    }
                }

                if (sv.Gender)
                {
                    this.rbNam.Checked = true;
                } else
                {
                    this.rbNu.Checked = true;
                }

                this.dtpNgaySinh.Value = sv.NS;
            }
        }

        private void CreateCbbLopSH()
        {
            List<LopSH> list = BLL_QLSV.Instance.GetAllLopSH();

            if (list.Count > 0)
            {
                // Add LopSH from DB
                foreach (LopSH lop in list)
                {
                    this.cbbLopSH.Items.Add(new CBBItem()
                    {
                        key = lop.NameLop,
                        value = lop.ID_Lop.ToString()
                    });
                }

                this.cbbLopSH.SelectedIndex = 0;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string NameSV = this.txtTen.Text.Trim();
            DateTime NS = this.dtpNgaySinh.Value;
            bool Gender = this.rbNam.Checked;
            int ID_Lop = Convert.ToInt32(((CBBItem)this.cbbLopSH.SelectedItem).value);

            if (NameSV == "")
            {
                MessageBox.Show("Ten vui long khong de trong");
                return;
            }

            SV sv = new SV()
            {
                MSSV = this.MSSV,
                NameSV = NameSV,
                NS = NS,
                Gender = Gender,
                ID_Lop = ID_Lop
            };
            
            // create new SV
            if (this.MSSV == -1)
            {
                BLL_QLSV.Instance.AddSV(sv);
            } else
            {
                // Edit existing SV
                BLL_QLSV.Instance.Update(sv);
            }
            ReloadViewForm1();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
