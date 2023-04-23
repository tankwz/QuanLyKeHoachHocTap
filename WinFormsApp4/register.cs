using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WinFormsApp4
{
    internal class register
    {
        //private List<studentinfo> students = new List<studentinfo>();

        public bool RegisterStudent(string id, string password, string name)
        {
            // Check if the student ID already exists in the database
            bool studentExists = false;
            string connstring = "Data Source = DESKTOP-IVA70I6;"
                                        + "Initial Catalog = KHHT;"
                                        + "Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM students WHERE st_id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        studentExists = true;
                    }
                }
            }

            if (studentExists)
            {
                MessageBox.Show("A student with the same ID already exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

           string passwordHash = SHA256enc.Hash(password);


            //students.Add(newStudent);
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string query = "INSERT INTO students (st_id, st_password_hash, st_name) VALUES (@id, @password, @name)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", passwordHash);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.ExecuteNonQuery();
                }
            }

            // Display a success message
            MessageBox.Show("Student registered successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }

    }
}
