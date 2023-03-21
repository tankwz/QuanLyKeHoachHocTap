using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.AxHost;

namespace WinFormsApp4
{
    public partial class Kehoachhoctap : Form
    {

        public Kehoachhoctap()
        {
            InitializeComponent();
        }

        public static string getBetween(string strSource, string strStart, string strEnd)
        {
            string result = "";
            int Start, End;
            int endl = strEnd.Length;
            int startl = strStart.Length;
            while (strSource.Contains(strStart) && strSource.Contains(strEnd))
            {
                Start = 0;
                End = 0;
                Start = strSource.IndexOf(strStart, 0) + startl;
                End = strSource.IndexOf(strEnd, Start);
                result += strSource.Substring(Start, End - Start);
                strSource = strSource.Remove(Start - startl, startl + endl + (End - Start));
                result += "-";
            }
            //      result = result.Remove(result.Length-1, 1);
            return result;
        }

        private int getid(string strSource, studentSubjects[] subject, int num)
        {
            int Start;
            while (strSource.Contains("-"))

            {
                Start = strSource.IndexOf("-", 0);
                subject[num + 1].Id = strSource.Substring(Start - 5, 5);
                if (strSource.Length > 5)
                    strSource = strSource.Remove(Start - 5, 6);
                num++;
            }
            subject[0].Id = num.ToString();
            return num;
        }

        private void gethk(string strSource, studentSubjects[] subjects)
        {
            string result = "";
            string id, strTrim2, strTrim3, mark;
            int Start, drl, markStart;
            int a = 1;
            int i = 0;
            string strTrim = strSource.Replace("\t", "").Replace("\n", "").Replace("\r", "");
            while (strTrim.Contains("Học Kỳ 1") || strTrim.Contains("Học Kỳ 2"))
            {
                if (strTrim.Contains("Học Kỳ 1"))
                {
                    Start = strTrim.IndexOf("Học Kỳ 1", 0);
                    drl = strTrim.IndexOf("Điểm Rèn Luyện ", 0);
                    strTrim2 = strTrim.Substring(Start, drl + 14 - Start);
                    id = getBetween(strTrim2, "<tr>    <td>", "</td>");
                    i = getid(id, subjects, i);

                    result = strTrim.Substring(Start, 24);

                    strTrim3 = strTrim2;

                    for (; a <= Int32.Parse(subjects[0].Id); a++)
                    {
                        subjects[a].Hknamhoc = result;
                        markStart = strTrim3.IndexOf("</td>    <td align=\"left\">", 0) + 26;
                        mark = strTrim3.Substring(markStart, 3);
                        subjects[a].Mark = mark;
                        strTrim3 = strTrim3.Remove(markStart - 28, 152);

                    }
                    strTrim = strTrim.Remove(Start, drl + 14 - Start);
                }
                if (strTrim.Contains("Học Kỳ 2"))
                {
                    Start = strTrim.IndexOf("Học Kỳ 2", 0);
                    drl = strTrim.IndexOf("Điểm Rèn Luyện ", 0);
                    strTrim2 = strTrim.Substring(Start, drl + 14 - Start);
                    id = getBetween(strTrim2, "<tr>    <td>", "</td>");
                    i = getid(id, subjects, i);

                    result = strTrim.Substring(Start, 24);

                    strTrim3 = strTrim2;

                    for (; a <= Int32.Parse(subjects[0].Id); a++)
                    {
                        subjects[a].Hknamhoc = result;
                        markStart = strTrim3.IndexOf("</td>    <td align=\"left\">", 0) + 26;
                        mark = strTrim3.Substring(markStart, 3);
                        subjects[a].Mark = mark;
                        strTrim3 = strTrim3.Remove(markStart - 28, 152);

                    }
                    strTrim = strTrim.Remove(Start, drl + 14 - Start);
                }
                if (strTrim.Contains("Học Kỳ Hè"))
                {
                    Start = strTrim.IndexOf("Học Kỳ Hè", 0);
                    drl = strTrim.IndexOf("Điểm Rèn Luyện ", 0);
                    strTrim2 = strTrim.Substring(Start, drl + 14 - Start);
                    id = getBetween(strTrim2, "<tr>    <td>", "</td>");
                    i = getid(id, subjects, i);

                    result = strTrim.Substring(Start, 24);

                    strTrim3 = strTrim2;

                    for (; a <= Int32.Parse(subjects[0].Id); a++)
                    {
                        subjects[a].Hknamhoc = result;
                        markStart = strTrim3.IndexOf("</td>    <td align=\"left\">", 0) + 26;
                        mark = strTrim3.Substring(markStart, 3);
                        subjects[a].Mark = mark;
                        strTrim3 = strTrim3.Remove(markStart - 28, 152);

                    }
                    strTrim = strTrim.Remove(Start, drl + 14 - Start);
                }
            }
        }

        private void getMark(string strSource, studentSubjects[] subject)
        {
            int Start;
            int i = 0;
            while (strSource.Contains("-"))
            {
                Start = strSource.IndexOf("-", 0);
                subject[i + 1].Mark = strSource.Substring(Start - 5, 5);
                if (strSource.Length > 5)
                    strSource = strSource.Remove(Start - 5, 6);
                i++;
            }
            subject[0].Id = i.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
    //        richTextBox1.Text = "";
            filehtml.FileName = "";
            filehtml.Filter = "Html-Files(*.html)|*.html";
            filehtml.ShowDialog(this);
            textBox1.Text = filehtml.FileName;
            string file = System.IO.File.ReadAllText(filehtml.FileName);
            studentSubjects[] test1 = new studentSubjects[200];

            for (int i = 0; i < 200; ++i)
            {
                test1[i] = new studentSubjects();
            }
            gethk(file, test1);

            dataGridView1.DataSource = test1;

            string connstring = "Data Source = DESKTOP-IVA70I6;"
                + "Initial Catalog=KHHT;"
                + "Integrated Security=true";
            SqlConnection conn = new SqlConnection(connstring);
            conn.Open();
            string query = "select KTPM_K44.sub_id, name, credits, prerequisite, mandatory, groupz from subjects,KTPM_K44 where KTPM_K44.sub_id = subjects.sub_id ";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            string output = "";
            while (reader.Read())
            {
                output = output + " = " + reader.GetValue(0) + "-" + reader.GetValue(1)
                   + reader.GetValue(2);
            }



            conn.Close();





            /*
                        for (int i = 0; i < test1.Length; i++)
                        {
                            richTextBox1.Text = richTextBox1.Text + i + ". " + test1[i].Hknamhoc;
                            richTextBox1.Text = richTextBox1.Text + "Diem: " + test1[i].Mark;
                            richTextBox1.Text = richTextBox1.Text + " MHP: " + test1[i].Id + " \n";
                        }*/


        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {


        /*    float scaleX = ((float)Screen.PrimaryScreen.WorkingArea.Width / 1024);
            float scaleY = ((float)Screen.PrimaryScreen.WorkingArea.Height / 768);
            SizeF aSf = new SizeF(scaleX, scaleY);
            this.Scale(aSf);
            this.AutoScaleMode = AutoScaleMode.Font;
            AutoSize = false;*/
            this.BackColor = Color.FromArgb(240, 244, 252);
        }
    }
}
