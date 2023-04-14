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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
                dataGridView.Location = new Point(dataGridView.Location.X + 180, dataGridView.Location.Y + 25);
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
            /*
            dataGridView.Columns.Add("Stt", "Stt");
            dataGridView.Columns["Stt"].DataPropertyName = "Order";
            dataGridView.Columns["Stt"].Width = 50;
            */
            // Add "Id" column as ComboBox
            // Add "Name" column as ComboBox
            DataGridViewComboBoxColumn nameColumn = new DataGridViewComboBoxColumn();
            nameColumn.Name = "Name";
            nameColumn.HeaderText = "Tên học phần";
            nameColumn.DataPropertyName = "Name";
            nameColumn.Width = 400;
            var source1 = subject.Where(s => (s.Mandatory != "0") && ((s.Done == 0) || (s.Done == totalhk))).Select(s => new { IdName = $"{s.Id} - {s.Name}", s.Id, s.Name, s.Credits, s.Prerequisite, s.Mandatory, s.Groupz, s.Done }).Distinct().ToList();
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
            dataGridView.Columns.Add("Done", "Done");
            dataGridView.Columns["Credits"].DataPropertyName = "Credits";
            dataGridView.Columns["Prerequisite"].DataPropertyName = "Prerequisite";
            dataGridView.Columns["Groupz"].DataPropertyName = "Groupz";
            dataGridView.Columns["Mandatory"].DataPropertyName = "Mandatory";
            dataGridView.Columns["Done"].DataPropertyName = "Done";
            dataGridView.Columns["Credits"].Width = 50;
            dataGridView.Columns["Prerequisite"].Width = 120;
            dataGridView.Columns["Groupz"].Width = 120;
            dataGridView.Columns["Mandatory"].Width = 50;
            dataGridView.Columns["Done"].Width = 50;
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

            foreach (subjects sj in subject)
            {
                if (sj.Done == totalhk)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    DataGridViewComboBoxCell nameCell = new DataGridViewComboBoxCell();
                    nameCell.DataSource = source1;
                    nameCell.DisplayMember = "IdName";
                    nameCell.ValueMember = "IdName";
                    if (source1.Any(s => s.IdName == $"{sj.Id} - {sj.Name}"))
                    {
                        var selectedItem = source1.FirstOrDefault(s => s.IdName == $"{sj.Id} - {sj.Name}");
                        nameCell.Value = $"{sj.Id} - {sj.Name}";

                        // source1.Remove(selectedItem);
                    }
                    else
                    {
                        // The value is not present in the ComboBox's DataSource, handle it here
                        nameCell.Value = null;
                        MessageBox.Show("Value is not valid for this cell.");
                    }
                    row.Cells.Add(nameCell);
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Credits });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Prerequisite });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Groupz });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Mandatory });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Done });
                    dataGridView.Rows.Add(row);
                    dataGridView.CellValueChanged += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
                    dataGridView.EditingControlShowing += (sender, e) =>
                    {

                        dataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
                    };
                }
            }

            dataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
            dataGridView.DataError += new DataGridViewDataErrorEventHandler(dataGridView_DataError);

            return p;
        }
        subjects[] subject;

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
                // Handle the value not valid error here
                MessageBox.Show("Value is not valid for this cell.");
                e.ThrowException = false;
            }
        }
        /*
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int check = 1;
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
                        dataGridView.Rows[e.RowIndex].Cells["Done"].Value = selectedSubject.Done;
                        //DataGridViewTextBoxCell otherCelldone = row.Cells["Done"] as DataGridViewTextBoxCell;
   
                        string[] prerequisites = selectedSubject.Prerequisite.Split(',');
                        string unsatisfiedPrerequisites = "";
                        foreach (string prerequisite in prerequisites)
                        {
                            if (!string.IsNullOrEmpty(prerequisite))
                            {
                                string prerequisiteId = prerequisite.Trim();
                                subjects prerequisiteSubject = subject.FirstOrDefault(s => s.Id == prerequisiteId);
                                if (prerequisiteSubject != null && prerequisiteSubject.Done == 0)
                                {
                                    unsatisfiedPrerequisites += string.Format("{0} - {1}\n", prerequisiteId, prerequisiteSubject.Name);
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(unsatisfiedPrerequisites))
                        {
                            cell.Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Credits"].Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Prerequisite"].Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Groupz"].Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Mandatory"].Value = null;
                            MessageBox.Show(string.Format("Môn học {0} - {1} chưa đáp ứng điều kiện tiên quyết:\n{2}",
                                        selectedSubject.Id, selectedSubject.Name, unsatisfiedPrerequisites));
                        }
                    }
                    

                    foreach (subjects sj in subject)
                    {
                        if (selectedSubject.Name == sj.Name) { sj.Done = totalhk; }
                    }
                }
            }
        }
      */


        private string prevSelectedSubjectName = "";

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
                        dataGridView.Rows[e.RowIndex].Cells["Done"].Value = selectedSubject.Done;

                        foreach (DataGridViewRow row in dataGridView.Rows)
                        {
                            if (row.Index == e.RowIndex)
                            {
                                DataGridViewTextBoxCell otherCelldone = row.Cells["Done"] as DataGridViewTextBoxCell;
                                if (otherCelldone != null && otherCelldone.Value != null)
                                {
                                    if (int.Parse(otherCelldone.Value.ToString()) == totalhk)
                                    {
                                        MessageBox.Show(otherCelldone.Value.ToString() + totalhk.ToString());
                                        cell.Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Credits"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Prerequisite"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Groupz"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Mandatory"].Value = null;
                                        MessageBox.Show("Môn học này đã được chọn", "Lưu ý");
                                        break;
                                    }
                                }
                            }
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
                                        MessageBox.Show("Môn học này đã được chọn", "Lưu ý");
                                        break;
                                    }
                                }
                            }
                        }

                        if (prevSelectedSubjectName != selectedName)
                        {
                            // set sj.Done of previous subject to 0
                            subjects prevSelectedSubject = subject.FirstOrDefault(s => s.Name == prevSelectedSubjectName);
                            if (prevSelectedSubject != null)
                            {
                                prevSelectedSubject.Done = 0;
                            }
                            prevSelectedSubjectName = selectedName;
                        }
                        string[] prerequisites = selectedSubject.Prerequisite.Split(',');
                        string unsatisfiedPrerequisites = "";
                        foreach (string prerequisite in prerequisites)
                        {
                            if (!string.IsNullOrEmpty(prerequisite))
                            {
                                string prerequisiteId = prerequisite.Trim();
                                subjects prerequisiteSubject = subject.FirstOrDefault(s => s.Id == prerequisiteId);
                                if (prerequisiteSubject != null && prerequisiteSubject.Done == 0)
                                {
                                    unsatisfiedPrerequisites += string.Format("{0} - {1}\n", prerequisiteId, prerequisiteSubject.Name);
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(unsatisfiedPrerequisites))
                        {
                            cell.Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Credits"].Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Prerequisite"].Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Groupz"].Value = null;
                            dataGridView.Rows[e.RowIndex].Cells["Mandatory"].Value = null;
                            MessageBox.Show(string.Format("Môn học {0} - {1} chưa đáp ứng điều kiện tiên quyết:\n{2}",
                                        selectedSubject.Id, selectedSubject.Name, unsatisfiedPrerequisites));
                        }
                        else
                        {
                            selectedSubject.Done = totalhk;
                            MessageBox.Show(selectedSubject.Done.ToString());
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
            if (textBox1.Text == "")
                return;
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
            addPanel(Int32.Parse(studentlist0[0].Name), studentlist0);
            totalhk = Int32.Parse(studentlist0[0].Name);
            // MessageBox.Show("first" + totalhk);
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
            them();
        }

        private void them()
        {
            totalhk++;
            addPanel1(totalhk, subject);
            flowLayoutPanel1.AutoScrollPosition = new Point(0, int.MaxValue);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            xoa();
            foreach (subjects sj in subject)
            {
                if (sj.Done == totalhk + 1)
                {
                    sj.Done = 0;
                }
            }
        }
        private void xoa()
        {
            string panelNameToRemove = "panelz" + totalhk;
            Control panelToRemove = flowLayoutPanel1.Controls.Find(panelNameToRemove, false).FirstOrDefault();
            if (panelToRemove != null)
            {
                flowLayoutPanel1.Controls.Remove(panelToRemove);
                panelToRemove.Dispose();
            }

            totalhk--;

        }

        List<string> selectedSubjects;
        private void button4_Click(object sender, EventArgs e)
        {


        }

        private void Thp_SelectedSubjectsSelected(object sender, List<string> selectedSubjects)
        {
            foreach (string st in selectedSubjects)
            {
                foreach (subjects sj in subject)
                {
                    if (sj.Id == st)
                    {
                        // MessageBox.Show(sj.Id);
                        sj.Done = totalhk;
                    }
                }
            }
            xoa();
            them();
        }

        /*

        private void SetSelectedSubjectsInDataGridView(DataGridView dataGridView, List<string> selectedSubjects)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                var idCell = row.Cells["Name"];
                if (idCell != null && idCell.Value != null && selectedSubjects.Contains(idCell.Value.ToString().Substring(0,5)))
                {
                    var nameCell = row.Cells["Name"];
                    if (nameCell != null && nameCell.Value != null)
                    {
                        string subjectName = nameCell.Value.ToString();
                        nameCell.Value = subjectName;
                    }
                }
            }
        }
        private void buttonFillComboBoxes_Click(object sender, EventArgs e)
        {
            foreach (Control control in flowLayoutPanel1.Controls)
            {
                if (control is Panel panel)
                {
                    var dataGridView = panel.Controls.Find("dataz", false).FirstOrDefault() as DataGridView;
                    if (dataGridView != null)
                    {
                        SetSelectedSubjectsInDataGridView(dataGridView, selectedSubjects);
                    }
                }
            }
        }

        */

        private void button5_Click(object sender, EventArgs e)
        {
            ThemHocPhan thp = new ThemHocPhan(subject);
            thp.SelectedSubjectsSelected += Thp_SelectedSubjectsSelected;
            thp.Show();
        }
    }
}
