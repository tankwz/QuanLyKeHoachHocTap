using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class Login
    {
        public bool LoginStudent(string id, string password)
        {
            bool studentExists = false;
            string connstring = "Data Source = DESKTOP-IVA70I6;"
                                        + "Initial Catalog = KHHT;"
                                        + "Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM students WHERE st_id = @id AND st_password_hash = @password";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@password", SHA256enc.Hash(password));
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        studentExists = true;
                    }
                }
            }

            if (studentExists)
            {
              //  MessageBox.Show("Student login successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            else
            {
                MessageBox.Show("Sai mã sinh viên hoặc mật khẩu.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
