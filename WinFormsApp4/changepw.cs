using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class changepw
    {
        public bool ChangePassword(string id, string currentPassword, string newPassword)
        {
            // Check if the student exists in the database
            bool studentExists = false;
            string connstring = "Data Source = DESKTOP-IVA70I6;"
                                            + "Initial Catalog = KHHT;"
                                            + "Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM students WHERE st_id = @id AND st_password_hash = @currentPassword";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@currentPassword", SHA256enc.Hash(currentPassword));
                    int count = (int)cmd.ExecuteScalar();
                    if (count > 0)
                    {
                        studentExists = true;
                    }
                }
            }

            if (!studentExists)
            {
                MessageBox.Show("Mã số sinh viên hoặc mật khẩu không đúng", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Update the student's password
            string newPasswordHash = SHA256enc.Hash(newPassword);

            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string query = "UPDATE students SET st_password_hash = @newPassword WHERE st_id = @id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@newPassword", newPasswordHash);
                    cmd.ExecuteNonQuery();
                }
            }

            // Display a success message
            MessageBox.Show("Thay đổi mật khẩu thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return true;
        }
    }
}
