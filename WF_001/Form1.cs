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
    public partial class Form1 : Form
    {
        private delegate void PointToForm2(SV sv, bool isEdit);

        private PointToForm2 pointToForm2;

        public Form1()
        {
            InitializeComponent();
            createComboBox();
            createCbbSort();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            int index = this.cbbLopSH.SelectedIndex;

            if (index == -1)
                index = 0; // default value == "ALL"

            int id = ((CBBItemTenLopSH)this.cbbLopSH.Items[index]).value;
            this.dgvDSSV.DataSource = CSDL.Instance.FilterSVByLopSH(id);
        }

        private void createComboBox()
        {
            DataRowCollection r = CSDL.Instance.dtLopSH.Rows;

            // Default
            this.cbbLopSH.Items.Add(new CBBItemTenLopSH(0, "All"));

            foreach (DataRow dr in r)
            {
                int value = (int)dr["Id"];
                string text = (string)dr["Ten"];

                this.cbbLopSH.Items.Add(new CBBItemTenLopSH(value, text));
            }
        }


        private void createCbbSort()
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = this.dgvDSSV.SelectedRows;

            if (r.Count > 0)
            {
                DataGridViewRow dgvRow = r[0];
                Form2 form2 = new Form2();
                form2.pointToForm1 = new Form2.PointToForm1(this.UpdateViewDSSV);

                string MSSV = dgvRow.Cells["MSSV"].Value.ToString();
                SV sv = CSDL.Instance.GetSVByMSSV(MSSV);

                this.pointToForm2 = new PointToForm2(form2.SetCurrentSVAndUpdateView);
                this.pointToForm2(sv, true);

                form2.Show();
            }

        }

        private void UpdateViewDSSV(SV sv)
        {
            CSDL.Instance.UpdateSV(sv);
            btnShow_Click(new object(), new EventArgs());
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.pointToForm1 = new Form2.PointToForm1(AddNewSV);

            SV sv = new SV();
            this.pointToForm2 = new Form1.PointToForm2(form2.SetCurrentSVAndUpdateView);
            this.pointToForm2(sv, false);

            form2.Show();
        }

        private void AddNewSV(SV sv)
        {
            CSDL.Instance.AddNewSV(sv);
            btnShow_Click(new object(), new EventArgs());
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection r = this.dgvDSSV.SelectedRows;

            if (r.Count > 0)
            {
                DataGridViewRow dgvRow = r[0];
                object o = dgvRow.Cells["MSSV"].Value;
                if (o == null)
                {
                    MessageBox.Show("Vui long chon hang co du lieu");
                    return;
                }
                string MSSV = o.ToString();
                
                if (CSDL.Instance.deleteSVByMSSV(MSSV))
                {
                    btnShow_Click(new object(), new EventArgs());
                } else
                {
                    MessageBox.Show("Khong tim thay MSSV tuong ung");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = this.txtSearch.Text;
            if (txt.Equals(""))
            {
                btnShow_Click(new object(), new EventArgs());
            }
            DataTable dt = CSDL.Instance.searchByName(txt);
            this.dgvDSSV.DataSource = dt;
        }
    }
}
