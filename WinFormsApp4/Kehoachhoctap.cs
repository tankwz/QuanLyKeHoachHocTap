using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.IO;

using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
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

        private void addPanel(int p, studentSubjects[] studentlist0)
        {
            int panelCount = p;
            flowLayoutPanel1.Controls.Clear();
            for (int i = 0; i < panelCount; i++)
            {
                var filteredList = studentlist0.Where(s => s.Count == i + 1).ToArray();
                int countz = 1;
                foreach (var s in filteredList)
                {

                    s.Order = countz;
                    countz++;
                }
                Panel panel = new Panel();
                panel.Height = 20;
                panel.Width = 1300;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Name = "panelz" + i.ToString();
                panel.BackColor = Color.White;
                Label label = new Label();
                label.Text = filteredList[0].Hknamhoc;
                label.Dock = DockStyle.Top;
                DataGridView dataGridView = new DataGridView();
                dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
                dataGridView.AutoGenerateColumns = false;
                dataGridView.Columns.Add("Stt", "Stt");
                dataGridView.Columns.Add("Id", "Mã học phần");
                dataGridView.Columns.Add("Name", "Tên học phần");
                dataGridView.Columns.Add("Credits", "Tín chỉ");
                dataGridView.Columns.Add("Marktext", "Điểm chữ");
                dataGridView.Columns.Add("Mark", "Điểm số");
                dataGridView.Columns.Add("Get", "Tích lũy");
                dataGridView.Columns["Stt"].DataPropertyName = "Order";
                dataGridView.Columns["Id"].DataPropertyName = "Id";
                dataGridView.Columns["Name"].DataPropertyName = "Name";
                dataGridView.Columns["Credits"].DataPropertyName = "Credits";
                dataGridView.Columns["Marktext"].DataPropertyName = "Marktext";
                dataGridView.Columns["Mark"].DataPropertyName = "Mark";
                dataGridView.Columns["Get"].DataPropertyName = "Get";
                dataGridView.Columns["Stt"].Width = 50;
                dataGridView.Columns["Id"].Width = 95;
                dataGridView.Columns["Name"].Width = 400;
                dataGridView.Columns["Credits"].Width = 80;
                dataGridView.Columns["Marktext"].Width = 80;
                dataGridView.Columns["Mark"].Width = 80;
                dataGridView.Columns["Get"].Width = 70;
                //  dataGridView.Dock = DockStyle.Fill;
                dataGridView.Location = new Point(dataGridView.Location.X + 180, dataGridView.Location.Y + 25);

                //  dataGridView.AutoSizeColumnsMode= DataGridViewAutoSizeColumnsMode.AllCells;
                //  dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView.Width = 1000;
                dataGridView.DataSource = filteredList;
                dataGridView.BackgroundColor = Color.White;
                dataGridView.BorderStyle = BorderStyle.None;

                var heightt = 40;
                foreach (var sj in filteredList)
                {
                    heightt += 28;
                }

                dataGridView.Height = heightt;
                panel.Height = heightt + 50;
                panel.Controls.Add(dataGridView);
                panel.Controls.Add(label);
                flowLayoutPanel1.Controls.Add(panel);


            }
        }

        private void checkpre()
        {
            string pre = "";

        }

        private int addPanel1(int p, subjects[] subject)
        {

            Panel panel = new Panel();
            panel.Height = 1000;
            panel.Width = 1300;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Name = "panelz" + p.ToString();
            panel.BackColor = Color.White;
            Label label = new Label();
            label.Dock = DockStyle.Top;
            DataGridView dataGridView = new DataGridView();
            dataGridView.Name = "dataz";//+ p.ToString();
            dataGridView.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dataGridView.AutoGenerateColumns = false;
            // Add "Stt" column
            dataGridView.Columns.Add("Stt", "Stt");
            dataGridView.Columns["Stt"].DataPropertyName = "Order";
            dataGridView.Columns["Stt"].Width = 50;
            // Add "Id" column as ComboBox
            // Add "Name" column as ComboBox
            DataGridViewComboBoxColumn nameColumn = new DataGridViewComboBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Tên học phần";
           // nameColumn.DisplayMember = "Name";
         //   nameColumn.ValueMember = "Name";
            nameColumn.DataPropertyName = "Name";
            nameColumn.Width = 400;
            var source1 = subject.Where(s => (s.Mandatory != "0") && (s.Done == 0)).Select(s => new { IdName = $"{s.Id} - {s.Name}", s.Name, s.Credits, s.Prerequisite, s.Mandatory ,s.Groupz,s.Done }).Distinct().ToList();
            nameColumn.DataSource = source1;
            nameColumn.DisplayMember = "IdName";
            nameColumn.ValueMember = "Name";
            //           nameColumn.DefaultCellStyle.BackColor = Color.White;
            //nameColumn.FlatStyle = FlatStyle.Flat;
            nameColumn.DefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.White };
            dataGridView.Columns.Add(nameColumn);
            dataGridView.Columns.Add("Credits", "Tín chỉ");
            dataGridView.Columns.Add("Prerequisite", "Tiên quyết");
            dataGridView.Columns.Add("Groupz", "Nhóm");
            dataGridView.Columns.Add("Mandatory", "Bắt buộc");
            dataGridView.Columns["Credits"].DataPropertyName = "Credits";
            dataGridView.Columns["Prerequisite"].DataPropertyName = "Prerequisite";
            dataGridView.Columns["Groupz"].DataPropertyName = "Groupz";
            dataGridView.Columns["Mandatory"].DataPropertyName = "Mandatory";
            dataGridView.Columns["Credits"].Width =50;
            dataGridView.Columns["Prerequisite"].Width = 120;
            dataGridView.Columns["Groupz"].Width = 120;
            dataGridView.Columns["Mandatory"].Width = 50;
            dataGridView.Location = new Point(dataGridView.Location.X + 180, dataGridView.Location.Y + 25);
            dataGridView.Width = 1000;
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            var heightt = 500;
            dataGridView.Height = heightt;
            panel.Height = heightt + 50;
            panel.Controls.Add(dataGridView);
            panel.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(panel);
            dataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView_CellEndEdit);
            return p;
        }
        subjects[] subject;

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var dataGridView = (DataGridView)sender;
            if (e.ColumnIndex == dataGridView.Columns["Name"].Index)
            {
                DataGridViewComboBoxCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                if (cell.Value != null)
                {
                    string selectedName = cell.Value.ToString();
                    subjects selectedSubject = subject.FirstOrDefault(s => s.Name == selectedName);
                    if (selectedSubject != null)
                    {
                        dataGridView.Rows[e.RowIndex].Cells["Credits"].Value = selectedSubject.Credits;
                        dataGridView.Rows[e.RowIndex].Cells["Prerequisite"].Value = selectedSubject.Prerequisite;
                        dataGridView.Rows[e.RowIndex].Cells["Groupz"].Value = selectedSubject.Groupz;
                        dataGridView.Rows[e.RowIndex].Cells["Mandatory"].Value = selectedSubject.Mandatory;
                        foreach (subjects sj in subject)
                        {
                            if (selectedSubject.Name == sj.Name) { sj.Done = totalhk; }
                        }
                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.Index != e.RowIndex)
                            {
                                DataGridViewComboBoxCell otherCell = row.Cells["Name"] as DataGridViewComboBoxCell;
                                if (otherCell != null && otherCell.Value != null)
                                {
                                    if (otherCell.Value.ToString() == selectedName)
                                    {
                                        cell.Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Credits"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Prerequisite"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Groupz"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Mandatory"].Value = null;
                                        MessageBox.Show("Lưu ý","Môn học này đã được chọn");
                                        break;
                                    }
                                }
                            }
                        }


                        string[] prerequisites = selectedSubject.Prerequisite.Split(',');
                        string unsatisfiedPrerequisites = "";
                        foreach (string prerequisite in prerequisites)
                        {
                            if (!string.IsNullOrEmpty(prerequisite))
                            {
                                string prerequisiteId = prerequisite.Trim();
                                subjects prerequisiteSubject = subject.FirstOrDefault(s => s.Id == prerequisiteId);
                                if (prerequisiteSubject != null && prerequisiteSubject.Done != 1)
                                {
                                    unsatisfiedPrerequisites += string.Format("{0} - {1}\n", prerequisiteId, prerequisiteSubject.Name);
                                }
                            }
                        }

                        if (!string.IsNullOrEmpty(unsatisfiedPrerequisites))
                        {
                            MessageBox.Show(string.Format("{0} - {1} has prerequisites that are not satisfied:\n{2}",
                                        selectedSubject.Id, selectedSubject.Name, unsatisfiedPrerequisites));
                        }


                    }
                }
            }
        }




        int totalhk;
        private void button1_Click(object sender, EventArgs e)
        {
            filehtml.FileName = "";
            filehtml.Filter = "Html-Files(*.html)|*.html";
            filehtml.ShowDialog(this);
            textBox1.Text = filehtml.FileName;
            string file = System.IO.File.ReadAllText(filehtml.FileName);
            studentSubjects[] studentlist0 = new studentSubjects[90];
            for (int u = 0; u < 90; ++u)
            {
                studentlist0[u] = new studentSubjects();
            }
            filter.gethk(file, studentlist0);

             subject = DatabaseConnection.connectdata();

            for (int a = 0; a < studentlist0.Length; a++)
            {
                if (!(studentlist0[a].Id == "HCVHT"))
                    studentlist0[a].Get = "*";
                studentlist0[a].Marktext = filter.gettextmark(studentlist0[a].Mark);
                if (studentlist0[a].Id == "HCVHT")
                {
                    studentlist0[a].Name = "Cố vấn học tập sinh hoạt lớp";
                    studentlist0[a].Mark = "";
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
            string twofirst2="";
            for (int f=0; f< subject.Length; f++)
            {
                if (subject[f].Mandatory == "all") continue;
                if (subject[f].Groupz.Length > 2 && (int.Parse(subject[f].Mandatory)<1))
                    twofirst2 = subject[f].Groupz.Substring(0, 2);
                for (int g=0; g<subject.Length; g++)
                {
                    if (subject[g].Groupz.Length < 2) continue;
                    if (subject[g].Groupz.Substring(0, 2) == twofirst2)
                        subject[g].Mandatory = "0";
                }
            }
           // dataGridView1.DataSource = filteredList;
            addPanel(Int32.Parse(studentlist0[0].Name), studentlist0);
            totalhk = Int32.Parse(studentlist0[0].Name);

        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(240, 244, 252);

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel1.ClientRectangle,
                Color.Black, 2, ButtonBorderStyle.Solid,
                Color.Black, 2, ButtonBorderStyle.Solid,
                Color.Black, 2, ButtonBorderStyle.Solid,
                Color.Black, 2, ButtonBorderStyle.Solid);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panel2.ClientRectangle,
              Color.Black, 2, ButtonBorderStyle.Solid,
              Color.Black, 2, ButtonBorderStyle.Solid,
              Color.Black, 2, ButtonBorderStyle.Solid,
              Color.Black, 2, ButtonBorderStyle.Solid);
        }



        private void flowLayoutPanel1_Scroll(object sender, ScrollEventArgs e)
        {
            //  flowLayoutPanel1.Invalidate();
        }

        private void flowLayoutPanel1_MouseWheel(object sender, MouseEventArgs e)
        {
            //            flowLayoutPanel1.Invalidate();
        }

        private void bordera_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, bordera.ClientRectangle,
              Color.Black, 2, ButtonBorderStyle.Solid,
              Color.Black, 2, ButtonBorderStyle.Solid,
              Color.Black, 2, ButtonBorderStyle.Solid,
              Color.Black, 2, ButtonBorderStyle.Solid);
        }

        private void button2_Click(object sender, EventArgs e)
        {

            addPanel1(totalhk, subject);
            flowLayoutPanel1.AutoScrollPosition = new Point(0, int.MaxValue);
            totalhk++;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            totalhk = totalhk - 1;
            string panelNameToRemove = "panelz" + totalhk;
            Control panelToRemove = flowLayoutPanel1.Controls.Find(panelNameToRemove, false).FirstOrDefault();
            if (panelToRemove != null)
            {
                flowLayoutPanel1.Controls.Remove(panelToRemove);
                panelToRemove.Dispose();
            }
            foreach (subjects sj in subject)
            {
                if (sj.Done == totalhk)
                {
                    sj.Done = 0;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                // Create the DataGridView and configure its properties
                DataGridView dataGridView1 = new DataGridView();
                dataGridView1.Dock = DockStyle.Fill;
                dataGridView1.AutoGenerateColumns = true;
                var filteredList2 = subject.Where(s => (s.Mandatory != "0") && (s.Done != 1)).ToArray();
               dataGridView1.DataSource = filteredList2;

                // Create a new form to display the DataGridView
                Form form = new Form();
                form.Text = "DataGridView Example";
                form.Size = new Size(600, 400);

                // Add the DataGridView to the form
                form.Controls.Add(dataGridView1);

                // Show the form
                form.ShowDialog();
            


        }
        private subjects[] GetData(subjects[] subject)
        {

            return subject;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
