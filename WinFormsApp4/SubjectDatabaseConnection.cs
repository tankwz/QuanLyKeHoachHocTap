using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class SubjectDatabaseConnection
    {
        public static subjects[]  connectdata()
        {
            string connstring = "Data Source = DESKTOP-IVA70I6;"
                 + "Initial Catalog = KHHT;"
                 + "Integrated Security = true;";
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string query = "select COUNT(*) from subjects,KTPM_K44 where KTPM_K44.sub_id = subjects.sub_id";
            SqlCommand cmd = new SqlCommand(query, conn);
            int totalsub = 0;
            totalsub = (int)cmd.ExecuteScalar();
            int i = 0;
            subjects[] subject = new subjects[totalsub];
            string query2 = "select KTPM_K44.sub_id, name, credits, prerequisite, mandatory, groupz,recommend, opentime from subjects,KTPM_K44 where KTPM_K44.sub_id = subjects.sub_id;";
            SqlCommand cmd2 = new SqlCommand(query2, conn);
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                subject[i] = new subjects(reader["sub_id"].ToString(), reader["name"].ToString(), int.Parse(reader["credits"].ToString()), reader["prerequisite"].ToString(), reader["mandatory"].ToString(), reader["groupz"].ToString(), int.Parse(reader["recommend"].ToString()), int.Parse(reader["opentime"].ToString())/*, int.Parse(reader["done"].ToString())*/);
                i++;
            }
            conn.Close();
            return subject;

        }

    }
}
