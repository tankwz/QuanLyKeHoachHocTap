using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class getbangdiem
    {
        private readonly string _connectionString;

        string connectionString = "Data Source = DESKTOP-IVA70I6;"
                     + "Initial Catalog = KHHT;"
                     + "Integrated Security = true;";

        public getbangdiem( )
        {
        }

        public studentSubjects[] GetStudentSubjects(string Mssv)
        {
            List<studentSubjects> studentSubjectsList = new List<studentSubjects>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT s.st_id, ss.orderz, ss.count, ss.hknamhoc, ss.marktext, ss.mark, ss.name, ss.id, ss.credits, ss.get, s.hk " +
                                     "FROM studentSubjects ss " +
                                     "INNER JOIN students s ON ss.st_id = s.st_id " +
                                     "WHERE ss.st_id = @Mssv", connection))

                {
                    command.Parameters.AddWithValue("@Mssv", Mssv);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            studentSubjects studentSubject = new studentSubjects();
                            if (!reader.IsDBNull(0))
                            {
                                studentSubject.St_id = reader.GetString(0);
                            }
                            if (!reader.IsDBNull(1))
                            {
                                studentSubject.Order = reader.GetInt32(1);
                            }
                            if (!reader.IsDBNull(2))
                            {
                                studentSubject.Count = reader.GetInt32(2);
                            }
                            if (!reader.IsDBNull(3))
                            {
                                studentSubject.Hknamhoc = reader.GetString(3);
                            }
                            if (!reader.IsDBNull(4))
                            {
                                studentSubject.Marktext = reader.GetString(4);
                            }
                            if (!reader.IsDBNull(5))
                            {
                                studentSubject.Mark = reader.GetString(5);
                            }
                            if (!reader.IsDBNull(6))
                            {
                                studentSubject.Name = reader.GetString(6);
                            }
                            if (!reader.IsDBNull(7))
                            {
                                studentSubject.Id = reader.GetString(7);
                            }
                            if (!reader.IsDBNull(8))
                            {
                                studentSubject.Credits = reader.GetInt32(8);
                            }
                            if (!reader.IsDBNull(9))
                            {
                                studentSubject.Get = reader.GetString(9);
                            }
                            studentSubjectsList.Add(studentSubject);
                        }
                    }
                }
            }

            bool yes = false;
            foreach (var studentSubject in studentSubjectsList)
            {
                if (studentSubject.St_id == Mssv) 
                    yes = true;
            }

            if (yes == true)
                return studentSubjectsList.ToArray();

            else return null;
    }
}
}
