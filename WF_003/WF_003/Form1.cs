using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_003
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = DBHelper.Instance.GetRecords("SELECT * FROM SV WHERE MSSV = 1");
            /*
            string connectionString = @"Data Source=HOVANVYDUT;Initial Catalog=StudentManagement;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);

            string query = "SELECT * FROM SV WHERE MSSV = @MSSV";
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.Add("@MSSV", SqlDbType.Int);
            cmd.Parameters["@MSSV"].Value = this.textBox1.Text;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            cnn.Open();

            dataAdapter.Fill(dataSet, "SV");

            cnn.Close();

            this.dataGridView1.DataSource = dataSet.Tables["SV"];
            */

            // ShowDataSet();

            /*
            string connectionString = @"Data Source=HOVANVYDUT;Initial Catalog=StudentManagement;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);

            try
            {
                SqlCommand cmd = new SqlCommand(this.textBox1.Text, cnn);

                cnn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

            }
            finally
            {
                cnn.Close();
            }

            Show();
            */
        }

        private void Show()
        {
            string connectionString = @"Data Source=HOVANVYDUT;Initial Catalog=StudentManagement;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);

            string query = "select * from SV";
            SqlCommand cmd = new SqlCommand(query, cnn);

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[]
            {
                new DataColumn("MSSV", typeof(int)),
                new DataColumn("NameSV", typeof(string)),
                new DataColumn("Gender", typeof(int)),
                new DataColumn("NS", typeof(DateTime)),
                new DataColumn("ID_Lop", typeof(int))
            });

            cnn.Open();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                DataRow dr = dt.NewRow();
                dr["MSSV"] = reader["MSSV"];
                dr["NameSV"] = reader["NameSV"];
                dr["Gender"] = reader["Gender"];
                dr["NS"] = reader["NS"];
                dr["ID_Lop"] = reader["ID_Lop"];

                dt.Rows.Add(dr);
            }

            cnn.Close();

            this.dataGridView1.DataSource = dt;
            //this.textBox1.Text = cnn.State.ToString();
        }

        public void ShowDataSet()
        {
            string connectionString = @"Data Source=HOVANVYDUT;Initial Catalog=StudentManagement;Integrated Security=True";
            SqlConnection cnn = new SqlConnection(connectionString);

            string query = "select * from SV";
            SqlCommand cmd = new SqlCommand(query, cnn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();

            cnn.Open();

            dataAdapter.Fill(dataSet, "SV");

            cnn.Close();

            this.dataGridView1.DataSource = dataSet.Tables["SV"];
        }
    }
}
