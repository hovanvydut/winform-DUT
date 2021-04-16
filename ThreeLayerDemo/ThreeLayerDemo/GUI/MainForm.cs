using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThreeLayerDemo.BLL;
using ThreeLayerDemo.DTO;

namespace ThreeLayerDemo.GUI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            CreateCbbLopSH();
            CreateCbbSort();
            Show(-1);
        }

        private void CreateCbbLopSH()
        {
            List<LopSH> list = BLL_QLSV.Instance.GetAllLopSH();
            
            if (list.Count > 0)
            {
                // Default "ALL"
                this.cbbLopSH.Items.Add(new CBBItem()
                {
                    key = "ALL",
                    value = "-1"
                });

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

        private void CreateCbbSort()
        {
            this.cbbSort.Items.Add(new CBBItem()
            {
                key = "None",
                value = "None"
            });

            this.cbbSort.Items.Add(new CBBItem() {
                key = "Ten giam dan",
                value = "NameSV"
            });

            this.cbbSort.Items.Add(new CBBItem()
            {
                key = "MSSV giam dan",
                value = "MSSV"
            });
            this.cbbSort.SelectedIndex = 0;
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            Show(GetIDLopFromCBB());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ReloadViewForm1 = new Form2.PointToForm1(ReloadView);
            form2.Show();
        }

        private void Show(int ID_Lop, string txtSearch = "", string sortBy = "")
        {
            List<SV> listSV;

            if (ID_Lop > 0)
            {
                listSV = BLL_QLSV.Instance.GetAllSVByIdLop(ID_Lop);
            } else
            {
                listSV = BLL_QLSV.Instance.GetAllSV();
            }

            List<int> listMSSV = new List<int>();

            foreach (SV sv in listSV)
            {
                listMSSV.Add(sv.MSSV);
            }

            switch (sortBy)
            {
                case "NameSV":
                    listSV = BLL_QLSV.ListSVSort(listMSSV, BLL_QLSV.sortNameSVDESC);
                    break;
                case "MSSV":
                    listSV = BLL_QLSV.ListSVSort(listMSSV, BLL_QLSV.sortMSSVDESC);
                    break;
            }
            
            if (!txtSearch.Equals(""))
            {
                listSV = BLL_QLSV.searchByText(txtSearch, listSV);
            }

            this.dgvDSSV.DataSource = listSV;
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (this.dgvDSSV.SelectedRows.Count > 0)
            {
                int MSSV = Convert.ToInt32(this.dgvDSSV.SelectedRows[0].Cells["MSSV"].Value);
                BLL_QLSV.Instance.DeleteSVByMSSV(MSSV);
                ReloadView();
            }
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            List<int> listMSSV = new List<int>();

            foreach (DataGridViewRow dr in this.dgvDSSV.Rows)
            {
                string s = dr.Cells["MSSV"].Value.ToString();
                listMSSV.Add(Convert.ToInt32(s));
            }

            string sortBy = GetSortByFromCBB();

            if (sortBy.Equals("NameSV"))
            {
                this.dgvDSSV.DataSource = BLL_QLSV.ListSVSort(listMSSV, BLL_QLSV.sortNameSVDESC);
            } else if (sortBy.Equals("MSSV"))
            {
                this.dgvDSSV.DataSource = BLL_QLSV.ListSVSort(listMSSV, BLL_QLSV.sortMSSVDESC);
            }
        }

        private void cbbSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.btnSort.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (this.dgvDSSV.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui long chon thong tin can chinh sua!");
                return;
            }
            int MSSV = Convert.ToInt32(this.dgvDSSV.SelectedRows[0].Cells["MSSV"].Value);
            Form2 form2 = new Form2(MSSV);
            form2.ReloadViewForm1 = new Form2.PointToForm1(ReloadView);
            form2.Show();
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string txtSearch = this.searchBox.Text;
            Show(GetIDLopFromCBB(), txtSearch, GetSortByFromCBB());
        }

        private int GetIDLopFromCBB()
        {
            return Convert.ToInt32(((CBBItem)this.cbbLopSH.SelectedItem).value);
        }

        private string GetSortByFromCBB()
        {
            CBBItem item = ((CBBItem)this.cbbSort.SelectedItem);
            if (item == null)
            {
                return "None";
            } else
            {
                return ((CBBItem)this.cbbSort.SelectedItem).value;
            }
        }

        private void ReloadView()
        {
            Show(GetIDLopFromCBB(), this.searchBox.Text, GetSortByFromCBB());
        }
    }
}
