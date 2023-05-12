using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WinFormsApp4
{
    internal class initiateData
    {
        public static subjects[] data(studentSubjects[] studentlist0, subjects[] subject, string file, ref int total)
        {

            //   filter.gethk(file, studentlist0);

            for (int u = 0; u < 90; ++u)
            {
                studentlist0[u] = new studentSubjects();
            }

            total = filter.gethk(file, studentlist0);
            subject = SubjectDatabaseConnection.connectdata();

            for (int a = 0; a < studentlist0.Length; a++)
            {
                if (!(studentlist0[a].Id == "HCVHT"))
                    studentlist0[a].Get = "*";
                studentlist0[a].Marktext = filter.gettextmark(studentlist0[a].Mark);
                if (studentlist0[a].Id == "HCVHT")
                {
                    studentlist0[a].Name = "Cố vấn học tập sinh hoạt lớp";
                    studentlist0[a].Mark = "";
                    studentlist0[a].Id = "SHCVHT";
                }
                if (studentlist0[a].Mark == "Vắn") studentlist0[a].Mark = "Vắng";
                if (studentlist0[a].Mark == "Rút") studentlist0[a].Mark = "Rút-HP";
                if (studentlist0[a].Mark == "10.") studentlist0[a].Mark = "10.0";
                for (int b = 0; b < subject.Length; b++)
                {
                    if (subject[b].Id == studentlist0[a].Id && subject[b].Id != null)
                    {
                        studentlist0[a].Name = subject[b].Name;
                        studentlist0[a].Credits = subject[b].Credits;
                        subject[b].Done = 1;
                        //MessageBox.Show("here");
                    }
                }
            }
            for (int c = 0; c < subject.Length; c++)
            {
                if (string.IsNullOrEmpty(subject[c].Groupz))
                    continue;

                string twofirst = subject[c].Groupz.Substring(0, 2);
                string twolast = string.Empty;

                if (subject[c].Groupz.Length > 2)
                    twolast = subject[c].Groupz.Substring(2, 2);

                if (subject[c].Done == 1)
                {
                    for (int d = 0; d < subject.Length; d++)
                    {
                        if (string.IsNullOrEmpty(subject[d].Groupz))
                            continue;

                        if (subject[d].Groupz.Length > 2 && subject[d].Groupz.Substring(0, 2) == twofirst)
                        {
                            if (subject[d].Groupz.Substring(2, 2) == twolast)
                                subject[d].Mandatory = (int.Parse(subject[d].Mandatory) - subject[c].Credits).ToString();
                        }
                        else if (subject[d].Groupz == twofirst)
                        {
                            subject[d].Mandatory = (int.Parse(subject[d].Mandatory) - subject[c].Credits).ToString();
                        }
                    }
                }
            }
            string twofirst2 = "";
            for (int f = 0; f < subject.Length; f++)
            {
                if (subject[f].Mandatory == "all") continue;
                if (subject[f].Groupz.Length > 2 && (int.Parse(subject[f].Mandatory) < 1))
                    twofirst2 = subject[f].Groupz.Substring(0, 2);
                for (int g = 0; g < subject.Length; g++)
                {
                    if (subject[g].Groupz.Length < 2) continue;
                    if (subject[g].Groupz.Substring(0, 2) == twofirst2)
                        subject[g].Mandatory = "0";
                }
            }
            // dataGridView1.DataSource = filteredList;
            if (studentlist0[0].Name == null) studentlist0[0].Name = 0.ToString();
            return subject;
            //string name = filter.getuserid(file);
            //label2.Text = name;
            // MessageBox.Show("first" + totalhk);
        }
    }
}
