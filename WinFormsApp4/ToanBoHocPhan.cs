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

namespace WinFormsApp4
{
    public partial class ToanBoHocPhan : Form
    {
        public ToanBoHocPhan()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connstring = "Data Source = DESKTOP-IVA70I6;"
            + "Initial Catalog = KHHT;"
            + "Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string query = "select KTPM_K44.sub_id, name, credits, prerequisite, mandatory, groupz from subjects,KTPM_K44 where KTPM_K44.sub_id = subjects.sub_id";

            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            int i = 0;
            subjects[] subject = new subjects[200];
            while (reader.Read())
            {
                subject[i] = new subjects(reader["sub_id"].ToString(), reader["name"].ToString(), reader["credits"].ToString(), reader["prerequisite"].ToString(), reader["mandatory"].ToString(), reader["groupz"].ToString());
                i++;
            }
            dataGridView1.DataSource=subject;
            MessageBox.Show(i.ToString());



            //DataTable dt = new DataTable();
            //  dt.Load(reader);
            //  dataGridView1.DataSource= dt;
            conn.Close();
        }
    }
}
