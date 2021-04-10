using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListViewDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetListView();
            setDSSV();
        }

        public void SetListView()
        {
            ColumnHeader c1 = new ColumnHeader();
            c1.Text = "MSSV";
            ColumnHeader c2 = new ColumnHeader();
            c2.Text = "Ten";
            ColumnHeader c3 = new ColumnHeader();
            c3.Text = "DTB";

            this.listView1.Columns.AddRange(new ColumnHeader[] { c1, c2, c3 });

            ListViewItem item1 = new ListViewItem();
            item1.Text = "101";
            ListViewItem.ListViewSubItem sbi11 = new ListViewItem.ListViewSubItem();
            sbi11.Text = "NVA";
            ListViewItem.ListViewSubItem sbi12 = new ListViewItem.ListViewSubItem();
            sbi12.Text = "1.1";
            item1.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { sbi11, sbi12 });

            ListViewItem item2 = new ListViewItem();
            item2.Text = "102";
            ListViewItem.ListViewSubItem sbi21 = new ListViewItem.ListViewSubItem();
            sbi21.Text = "NVB";
            ListViewItem.ListViewSubItem sbi22 = new ListViewItem.ListViewSubItem();
            sbi22.Text = "3";
            item2.SubItems.AddRange(new ListViewItem.ListViewSubItem[] { sbi21, sbi22 });

            this.listView1.Items.Add(item1);
            this.listView1.Items.Add(item2);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection r = this.listView1.SelectedItems;

            if (r.Count > 0)
            {
                string s = "";

                foreach (ListViewItem i in r)
                {
                    string MSSV = i.SubItems[0].Text;
                    string Ten = i.SubItems[1].Text;
                    String DTB = i.SubItems[2].Text;
                    s += MSSV + ", " + Ten + ", " + DTB + "\n";
                }

                MessageBox.Show(s);
            }
        }

        public void setDSSV()
        {
            SV[] arr = new SV[]
            {
                new SV
                {
                    MSSV = "101", Ten = "NVA", DTB = 1.1, GioiTinh = true
                },
                new SV
                {
                    MSSV = "102", Ten = "NVB", DTB = 2.1, GioiTinh = false
                },
                new SV
                {
                    MSSV = "103", Ten = "NVC", DTB = 3.1, GioiTinh = true
                }
            };

            DataTable dt = new DataTable();

            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV"),
                new DataColumn("Ten"),
                new DataColumn("DTB"),
                new DataColumn("GioiTinh", typeof(bool))
            });

            foreach (SV i in arr)
            {
                DataRow row = dt.NewRow();
                row["MSSV"] = i.MSSV;
                row["Ten"] = i.Ten;
                row["DTB"] = i.DTB.ToString();
                row["GioiTinh"] = i.GioiTinh;
                dt.Rows.Add(row);
            }

            this.dataGridView1.DataSource = dt;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewSelectedRowCollection r = this.dataGridView1.SelectedRows;

            if (r.Count > 0)
            {
                string s = "";

                foreach (DataGridViewRow i in r)
                {
                    string MSSV = i.Cells["MSSV"].Value.ToString();
                    string Ten = i.Cells["Ten"].Value.ToString();
                    string DTB = i.Cells["DTB"].Value.ToString();
                    string GioiTinh = i.Cells["GioiTinh"].Value.ToString();

                    s += MSSV + ", " + Ten + ", " + DTB + ", " + GioiTinh + "\n";
                }

                MessageBox.Show(s);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog f = new OpenFileDialog();
            f.Filter = "All|*.*|Excel|*.xlsx";
            DialogResult r = f.ShowDialog();

            if (r == DialogResult.OK)
            {
                MessageBox.Show(f.FileName);
            }
        }
    }
}
