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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CreateComboboxLopSH();
            CreateComboboxSort();
            Show(0);
        }

        private void CreateComboboxLopSH()
        {
            this.cbbLopSH.Items.Add(new MapCbbTenLopSH("ALL", 0));
            foreach (LopSH lopSH in CSDL_OOP.Instance.GetAllLopSH())
            {
                this.cbbLopSH.Items.Add(new MapCbbTenLopSH(lopSH.Ten, lopSH.Id));
            }
            this.cbbLopSH.SelectedIndex = 0;
        }

        private void CreateComboboxSort()
        {
            this.cbbSort.Items.Add("MSSV");
            this.cbbSort.Items.Add("Ten");
        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            int lopShId = GetSelectedLopSHId();
            Show(lopShId);
        }

        private void Show(int idLopSH, string searchText = "", int sortBy = -1)
        {
            List<SV> tmpList = CSDL_OOP.Instance.FindSVsByLopSHId(idLopSH);
            List<SV> result = new List<SV>();

            foreach(SV sv in tmpList)
            {
                if (sv.Ten.StartsWith(searchText))
                {
                    result.Add(sv);
                }
            }

            if (sortBy == 0)
            {
                result = CSDL_OOP.SortBy(CSDL_OOP.CompareMSSVDESC, result);
            } else if (sortBy == 1)
            {
                result = CSDL_OOP.SortBy(CSDL_OOP.CompareTenDESC, result);
            }

            this.dgvDSSV.DataSource = result;
        }


        public void ReloadGridView()
        {
            int lopSHId = GetSelectedLopSHId();
            string searchText = GetSearchText();

            Show(lopSHId, searchText);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            int lopSHId = GetSelectedLopSHId();
            string searchText = GetSearchText();

            Show(lopSHId, searchText);
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int count = this.dgvDSSV.SelectedRows.Count;

            if (count > 0)
            {
                int MSSV = GetSelectedMSSV();
                if (CSDL_OOP.Instance.DeleteSVByMSSV(MSSV)) {
                    int lopSHId = GetSelectedLopSHId();
                    string searchText = GetSearchText();

                    Show(lopSHId, searchText);
                } else
                {
                    MessageBox.Show(MSSV.ToString() + " khong ton tai");
                }   
            } else
            {
                MessageBox.Show("Vui long chon SV can xoa");
            }
        }

        private int GetSelectedLopSHId()
        {
            MapCbbTenLopSH map = (MapCbbTenLopSH)this.cbbLopSH.SelectedItem;
            return map.idLopSH;
        }

        private string GetSearchText()
        {
            return this.searchBox.Text;
        }

        /*
         * Return -1 if not selected
         */
        private int GetSelectedMSSV()
        {
            if (this.dgvDSSV.SelectedRows.Count == 0)
            {
                return -1;
            }

            DataGridViewRow dgvRow = this.dgvDSSV.SelectedRows[0];
            int mssv = Convert.ToInt32(dgvRow.Cells["MSSV"].Value.ToString());

            return mssv;
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            int lopSHId = GetSelectedLopSHId();
            string searchText = GetSearchText();

            Show(lopSHId, searchText, this.cbbSort.SelectedIndex);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ReloadForm1 = new Form2.ReloadGridViewForm1(this.ReloadGridView);
            form2.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int MSSV = GetSelectedMSSV();

            if (MSSV == -1)
            {
                MessageBox.Show("Vui long chon SV can xoa");
                return;
            }

            Form2 form2 = new Form2(MSSV);
            form2.ReloadForm1 = new Form2.ReloadGridViewForm1(this.ReloadGridView);
            form2.Show();
        }
    }
}
