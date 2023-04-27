using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace WinFormsApp4
{
    internal class addStudentSujecttoDB
    {
        public void addstudent(studentSubjects[] studentlist0)
        {
            string connstring = "Data Source = DESKTOP-IVA70I6;"
            + "Initial Catalog = KHHT;"
            + "Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string query = "INSERT INTO studentSubjects (st_id, orderz, count, hknamhoc, marktext, mark, name, id, credits, get) " +
                               "VALUES (@st_id, @orderz, @count, @hknamhoc, @marktext, @mark, @name, @id, @credits, @get)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    foreach (studentSubjects ss in studentlist0)
                    {
                        if (ss.Id == null) ss.Id = " ";
                        if (ss.Order == null) ss.Order = -9999;
                        if (ss.Count == null) ss.Count = -9999;
                        if (ss.Id == null) ss.Id = " ";
                        if (ss.Id == null) ss.Id = " ";
                        if (ss.Id == null) ss.Id = " ";
                        if (ss.Id == null) ss.Id = " ";

                        if (ss.Id == null) ss.Id = " ";
                        if (ss.Id == null) ss.Id = " ";
                    }
                    foreach (studentSubjects ss in studentlist0)
                    {
                        cmd.Parameters.Clear();
                        if (ss.Id == null)
                        cmd.Parameters.AddWithValue("@st_id", DBNull.Value);
                        else
                        cmd.Parameters.AddWithValue("@st_id", ss.St_id);

                        if (ss.Order == null)
                        {
                            cmd.Parameters.AddWithValue("@orderz", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@orderz", ss.Order);
                        }

                        if (ss.Count == null)
                        {
                            cmd.Parameters.AddWithValue("@count", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@count", ss.Count);
                        }

                        if (ss.Hknamhoc == null)
                        {
                            cmd.Parameters.AddWithValue("@hknamhoc", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@hknamhoc", ss.Hknamhoc);
                        }

                        if (ss.Marktext == null)
                        {
                            cmd.Parameters.AddWithValue("@marktext", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@marktext", ss.Marktext);
                        }

                        if (ss.Mark == null)
                        {
                            cmd.Parameters.AddWithValue("@mark", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@mark", ss.Mark);
                        }

                        if (ss.Name == null)
                        {
                            cmd.Parameters.AddWithValue("@name", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@name", ss.Name);
                        }

                        if (ss.Id == null)
                        {
                            cmd.Parameters.AddWithValue("@id", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@id", ss.Id);
                        }

                        if (ss.Credits == null)
                        {
                            cmd.Parameters.AddWithValue("@credits", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@credits", ss.Credits);
                        }

                        if (ss.Get == null)
                        {
                            cmd.Parameters.AddWithValue("@get", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@get", ss.Get);
                        }

                        cmd.ExecuteNonQuery();
                    }

                    

                }


                conn.Close();
            }
        }
        public void UpdateHk(string st_id, int hk)
        {
            string connstring = "Data Source = DESKTOP-IVA70I6;"
                                + "Initial Catalog = KHHT;"
                                + "Integrated Security = true;";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                conn.Open();
                string query = "UPDATE students SET hk = @hk WHERE st_id = @st_id";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@hk", hk);
                    cmd.Parameters.AddWithValue("@st_id", st_id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}

    