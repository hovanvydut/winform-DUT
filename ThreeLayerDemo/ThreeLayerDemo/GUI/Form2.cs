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
        private string MSSV;
        public Form2(string MSSV = "-1")
        {
            InitializeComponent();
            CreateCbbLopSH();

            this.MSSV = MSSV;
            RenderView();
        }


        private void RenderView()
        {
            // Edit mode
            if (!this.MSSV.Equals("-1"))
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

                this.txtMSSV.Enabled = false;
                this.txtMSSV.ReadOnly = true;
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
            string MSSV = removeAllWhiteSpace(this.txtMSSV.Text.Trim());
            string NameSV = this.txtTen.Text.Trim();
            DateTime NS = this.dtpNgaySinh.Value;
            bool Gender = this.rbNam.Checked;
            int ID_Lop = Convert.ToInt32(((CBBItem)this.cbbLopSH.SelectedItem).value);

            if (NameSV == "")
            {
                MessageBox.Show("Ten vui long khong de trong");
                return;
            }

            SV sv = null;
            
            // create new SV - ADD MODE
            if (this.MSSV.Equals("-1"))
            {
                if (MSSV == "")
                {
                    MessageBox.Show("ID vui long khong de trong");
                    return;
                }

                if (!BLL_QLSV.Instance.isUniqueId(MSSV))
                {
                    MessageBox.Show("ID bi trung. Vui long chon ID khac!");
                    return;
                }

                sv = new SV()
                {
                    MSSV = MSSV,
                    NameSV = NameSV,
                    NS = NS,
                    Gender = Gender,
                    ID_Lop = ID_Lop
                };
                BLL_QLSV.Instance.AddSV(sv);
            } else
            {
                // Edit existing SV - EDIT MODE
                sv = new SV()
                {
                    MSSV = this.MSSV,
                    NameSV = NameSV,
                    NS = NS,
                    Gender = Gender,
                    ID_Lop = ID_Lop
                };
                BLL_QLSV.Instance.Update(sv);
            }
            ReloadViewForm1();
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private static string removeAllWhiteSpace(string txt)
        {
            string result = "";
            foreach (char c in txt)
            {
                if (!c.Equals(' '))
                {
                    result += c;
                }
            }
            return result;
        }
    }
}
