using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        private string Mssv;
        public Kehoachhoctap(string mssv)
        {
            this.Mssv = mssv;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }



        private void addPanel(int p, studentSubjects[] studentlist0)
        {
            int panelCount = p;
            flowLayoutPanel1.Controls.Clear();
            double allavg = 0;
            double allcountcre = 0;
            double allcountcredisplay = 0;
            for (int i = 0; i < panelCount; i++)
            {
                //  studentlist0[4].Id
                var filteredList = studentlist0.Where(s => s.Count == i + 1).OrderBy(s => s.Id).ToArray();
                int countz = 1;
                double avg = 0;
                double allcre = 0;
                foreach (var s in filteredList)
                {
                    /*   if (s.Id?.Substring(0, 3) != null && s.Id.Substring(0, 3) == "TC0")
                           continue;*/
                    switch (s.Marktext.ToUpper())
                    {
                        case "A":
                            avg += s.Credits * 4;
                            allcre += s.Credits;
                            allcountcredisplay += s.Credits;
                            if (s.Name.Substring(s.Name.Length - 3, 3) != "(*)")
                            {
                                allavg += s.Credits * 4; allcountcre += s.Credits;
                            };
                            break;
                        case "B+":
                            avg += s.Credits * 3.5;
                            allcre += s.Credits;
                            allcountcredisplay += s.Credits;
                            if (s.Name.Substring(s.Name.Length - 3, 3) != "(*)")
                            { allavg += s.Credits * 3.5; allcountcre += s.Credits; };
                            break;
                        case "B":
                            avg += s.Credits * 3;
                            allcre += s.Credits;
                            allcountcredisplay += s.Credits;
                            if (s.Name.Substring(s.Name.Length - 3, 3) != "(*)")
                            { allavg += s.Credits * 3; allcountcre += s.Credits; };
                            break;
                        case "C+":
                            avg += s.Credits * 2.5;
                            allcre += s.Credits;
                            allcountcredisplay += s.Credits;
                            if (s.Name.Substring(s.Name.Length - 3, 3) != "(*)")
                            { allavg += s.Credits * 2.5; allcountcre += s.Credits; };
                            break;
                        case "C":
                            avg += s.Credits * 2;
                            allcre += s.Credits;
                            allcountcredisplay += s.Credits;
                            if (s.Name.Substring(s.Name.Length - 3, 3) != "(*)")
                            { allavg += s.Credits * 2; allcountcre += s.Credits; };
                            break;
                        case "D+":
                            avg += s.Credits * 1.5;
                            allcre += s.Credits;
                            allcountcredisplay += s.Credits;
                            if (s.Name.Substring(s.Name.Length - 3, 3) != "(*)")
                            { allavg += s.Credits * 1.5; allcountcre += s.Credits; };
                            break;
                        case "D":
                            avg += s.Credits * 1;
                            allcre += s.Credits;
                            allcountcredisplay += s.Credits;
                            if (s.Name.Substring(s.Name.Length - 3, 3) != "(*)")
                            { allavg += s.Credits * 1; allcountcre += s.Credits; };
                            break;
                        case "F":
                            allcre += s.Credits;
                            break;
                        case "W":
                            allcre += 0;
                            break;
                        default:
                            avg += s.Credits * 0;
                            allcre += s.Credits;
                            break;
                    }
                    if (s.Mark == null) allcre += 0;
                    s.Order = countz;
                    countz++;
                }
                //MessageBox.Show(allcountcre.ToString());
                avg = Math.Round(avg / allcre, 2);
                //if (allcountcre = 0)
                double allavg2;
                allavg2 = Math.Round(allavg / allcountcre, 2);

                // avg = avg / allcre;
                Panel panel = new Panel();
                panel.Height = 20;
                panel.Width = 1300;
                panel.BorderStyle = BorderStyle.FixedSingle;
                panel.Name = "panelz" + i.ToString();
                panel.BackColor = Color.White;
                Label lbhocky = new Label();

                Semester semester = new Semester();
                lbhocky.Text = semester.Semesterk44ktmp[filteredList[0].Count];
                lbhocky.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                lbhocky.ForeColor = Color.White;
                lbhocky.Dock = DockStyle.Top;
                lbhocky.TextAlign = ContentAlignment.MiddleCenter;
                lbhocky.Size = new Size(1300, 28);
                lbhocky.BackColor = Color.Cyan;
                lbhocky.BackColor = Color.FromArgb(81, 140, 196);
                // bitmap
                Bitmap gradientBitmap = new Bitmap(lbhocky.Width, lbhocky.Height);
                using (Graphics g = Graphics.FromImage(gradientBitmap))
                {
                    g.SmoothingMode = SmoothingMode.HighQuality;
                    LinearGradientBrush brush = new LinearGradientBrush(
                        new Point(0, 0),
                        new Point(0, lbhocky.Height),
                        Color.FromArgb(81, 140, 196),
                        Color.FromArgb(3, 57, 131));
                    g.FillRectangle(brush, 0, 0, lbhocky.Width, lbhocky.Height);
                }
                // label.AutoSize = true;
                lbhocky.BackgroundImage = gradientBitmap;
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
                //dataGridView.Columns["Mark"].
                dataGridView.Location = new Point(dataGridView.Location.X + 180, dataGridView.Location.Y + 45);
                dataGridView.Width = 1000;
                dataGridView.DataSource = filteredList;
                dataGridView.BackgroundColor = Color.White;
                dataGridView.BorderStyle = BorderStyle.None;
                dataGridView.CellFormatting += (sender, e) =>
                {
                    if (e.ColumnIndex == dataGridView.Columns["Mark"].Index && e.Value != null &&
                        (e.Value.ToString() == "Vắng" || e.Value.ToString() == "Rút-HP" ||
                        (double.TryParse(e.Value.ToString(), out double markValue) && markValue < 4)))
                    {
                        e.CellStyle.BackColor = Color.FromArgb(248, 50, 54);
                    }
                };
                var heightt = 60;
                foreach (var sj in filteredList)
                {
                    heightt += 28;
                }
                dataGridView.Height = heightt;
                panel.Height = heightt + 120;
                panel.Controls.Add(dataGridView);
                panel.Controls.Add(lbhocky);


                // label.AutoSize = true;
                Label lbavg = new Label();
                lbavg.Text = "Điểm trung bình học kỳ: " + avg.ToString();
                lbavg.Font = new Font("Segoe UI", 10);
                lbavg.AutoSize = true;
                panel.Controls.Add(lbavg);
                lbavg.Location = new Point(panel.Width - 500, panel.Height - lbavg.Height - 55);

                Label lballavg = new Label();
                lballavg.Text = "Điểm trung bình học kỳ tích lũy: " + allavg2.ToString();
                lballavg.Font = new Font("Segoe UI", 10);
                lballavg.AutoSize = true;
                panel.Controls.Add(lballavg);
                lballavg.Location = new Point(panel.Width - 500, panel.Height - lballavg.Height - 30);


                Label lbcredits = new Label();
                lbcredits.Text = "Số tín chỉ học kỳ: " + allcre.ToString();
                lbcredits.Font = new Font("Segoe UI", 10);
                lbcredits.AutoSize = true;
                panel.Controls.Add(lbcredits);
                lbcredits.Location = new Point(panel.Width - 1100, panel.Height - lbcredits.Height - 55);
                // flowLayoutPanel1.Controls.Add(lbcredits);
                Label lbcountcredits = new Label();
                lbcountcredits.Text = "Số tín chỉ tích lũy: " + allcountcredisplay.ToString();
                lbcountcredits.Font = new Font("Segoe UI", 10);
                lbcountcredits.AutoSize = true;
                panel.Controls.Add(lbcountcredits);
                lbcountcredits.Location = new Point(panel.Width - 1100, panel.Height - lbcountcredits.Height - 30);


                flowLayoutPanel1.Controls.Add(panel);
            }
        }


        private int addPanel1(int p, subjects[] subject)
        {

            //spawn table for new semester
            Panel panel = new Panel();
            panel.Height = 1000;
            panel.Width = 1300;
            panel.BorderStyle = BorderStyle.FixedSingle;
            panel.Name = "panelz" + p.ToString();
            panel.BackColor = Color.White;
            Label label = new Label();
            label.Dock = DockStyle.Top;
            DataGridView dataGridView = new DataGridView();
            dataGridView.Name = "dataz" + p.ToString();
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

            var source1 = subject.Where(s => (s.Mandatory != "0") && ((s.Done == 0) || (s.Done == totalhk))).Select(s => new { s.Id, s.Name, s.Credits, s.Prerequisite, s.Mandatory, s.Groupz, s.Done }).Distinct().ToList();
            int currenthk = totalhk;
            //           nameColumn.DefaultCellStyle.BackColor = Color.White;
            //nameColumn.FlatStyle = FlatStyle.Flat;

            Label lbhocky = new Label();

            Semester semester = new Semester();
            lbhocky.Text = semester.Semesterk44ktmp[totalhk];

            lbhocky.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lbhocky.ForeColor = Color.White;
            //lbhocky.Dock = DockStyle.Top;
            lbhocky.TextAlign = ContentAlignment.MiddleCenter;
            lbhocky.Size = new Size(1300, 28);
            lbhocky.BackColor = Color.Cyan;
            lbhocky.BackColor = Color.FromArgb(81, 140, 196);
            Bitmap gradientBitmap = new Bitmap(lbhocky.Width, lbhocky.Height);
            using (Graphics g = Graphics.FromImage(gradientBitmap))
            {
                g.SmoothingMode = SmoothingMode.HighQuality;
                LinearGradientBrush brush = new LinearGradientBrush(
                    new Point(0, 0),
                    new Point(0, lbhocky.Height),
                    Color.FromArgb(81, 140, 196),
                    Color.FromArgb(3, 57, 131));
                g.FillRectangle(brush, 0, 0, lbhocky.Width, lbhocky.Height);
            }
            // label.AutoSize = true;
            lbhocky.BackgroundImage = gradientBitmap;
            panel.Controls.Add(lbhocky);

            dataGridView.Columns.Add(new DataGridViewCheckBoxColumn()
            { HeaderText = "Chọn", DataPropertyName = "Selected", Name = "Selected" });
            dataGridView.Columns["Selected"].Width = 50;
            dataGridView.Columns.Add("Id", "Mã học phần");
            dataGridView.Columns.Add("Name", "Tên học phần");
            dataGridView.Columns.Add("Credits", "Tín chỉ");
            dataGridView.Columns.Add("Prerequisite", "Tiên quyết");
            dataGridView.Columns.Add("Groupz", "Nhóm");
            dataGridView.Columns.Add("Mandatory", "Bắt buộc");
            //dataGridView.Columns.Add("Done", "Hoàn thành");
            dataGridView.Columns.Add("Mark", "Điểm");
            dataGridView.Columns["Id"].DataPropertyName = "Id";
            dataGridView.Columns["Name"].DataPropertyName = "Name";
            dataGridView.Columns["Credits"].DataPropertyName = "Credits";
            dataGridView.Columns["Prerequisite"].DataPropertyName = "Prerequisite";
            dataGridView.Columns["Groupz"].DataPropertyName = "Groupz";
            dataGridView.Columns["Mandatory"].DataPropertyName = "Mandatory";
            dataGridView.Columns["Mark"].DataPropertyName = "Mark";
            // dataGridView.Columns["Done"].DataPropertyName = "Done";

            dataGridView.Columns["Id"].Width = 100;
            dataGridView.Columns["Name"].Width = 350;
            dataGridView.Columns["Credits"].Width = 80;
            dataGridView.Columns["Prerequisite"].Width = 120;
            dataGridView.Columns["Groupz"].Width = 120;
            dataGridView.Columns["Mandatory"].Width = 80;
            dataGridView.Columns["Mark"].Width = 80;
            // dataGridView.Columns["Done"].Width = 80;
            dataGridView.Location = new Point(dataGridView.Location.X + 100, dataGridView.Location.Y + 60);
            dataGridView.Width = 1070;
            // dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            var heightt = 400;
            dataGridView.Height = heightt;
            panel.Height = heightt + 120;
            panel.Controls.Add(dataGridView);
            panel.Controls.Add(label);
            flowLayoutPanel1.Controls.Add(panel);
            foreach (subjects sj in subject)
            {
                if (sj.Done == totalhk)
                {
                    DataGridViewRow row = new DataGridViewRow();

                    row.Cells.Add(new DataGridViewCheckBoxCell());

                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Id });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Name });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Credits });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Prerequisite });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Groupz });
                    row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Mandatory });
                    //   row.Cells.Add(new DataGridViewTextBoxCell() { Value = sj.Done });

                    dataGridView.Rows.Add(row);
                    /*  dataGridView.CellValueChanged += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
                      dataGridView.EditingControlShowing += (sender, e) =>
                      {
                          dataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
                      };*/
                }
            }
            // dataGridView.CellEndEdit += new DataGridViewCellEventHandler(dataGridView_CellValueChanged);
            dataGridView.DataError += new DataGridViewDataErrorEventHandler(dataGridView_DataError);

            System.Windows.Forms.Button deleteButton = new System.Windows.Forms.Button();
            deleteButton.Text = "Xóa học phần";
            deleteButton.Font = new Font("Segoe UI", 11);
            // deleteButton.bor
            //deleteButton.BackColor = Color.LightGray;
            deleteButton.ForeColor = Color.White;
            deleteButton.BackColor = Color.FromArgb(56, 114, 178);
            deleteButton.Width = 180;
            deleteButton.Height = 35;
            deleteButton.Location = new Point(panel.Width - 920, panel.Height - 45);
            List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            // Attach the EventHandler to the deleteButton
            deleteButton.Click += new EventHandler((sender, e) =>
            {
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (row.Cells["Selected"].Value != null && (bool)row.Cells["Selected"].Value)
                    {
                        // MessageBox.Show(row.Cells["Name"].Value.ToString());
                        if (filter.delpre(subject, row.Cells["Id"].Value.ToString()) == 0)
                        {
                            MessageBox.Show("kẹt");
                            return;
                        }

                        foreach (subjects sj in subject)
                        {

                            if (sj.Id == row.Cells["Id"].Value.ToString())
                            {
                                if (!string.IsNullOrEmpty(sj.Groupz))
                                {
                                    string firstTwo = sj.Groupz.Substring(0, 2);
                                    string lastTwo = string.Empty;

                                    if (sj.Groupz.Length > 2)
                                        lastTwo = sj.Groupz.Substring(2, 2);
                                    if (string.IsNullOrEmpty(lastTwo))
                                        foreach (subjects sj2 in subject)
                                        {
                                            //DataGridViewCheckBoxCell checkBoxCell = row.Cells["Selected"] as DataGridViewCheckBoxCell;
                                           // subjects checkedSubject = row.DataBoundItem as subjects;
                                           // MessageBox.Show(sj2.Name);
                                            if (sj2 != null && sj2.Groupz.StartsWith(firstTwo))
                                            {
                                                sj2.Mandatory = (int.Parse(sj2.Mandatory) + sj.Credits).ToString();
                                            }

                                        }
                                }

                                int temptotalhk = totalhk;
                                int tempdone = sj.Done;
                                { }

                                sj.Done = 0;
                                for (int z = tempdone + 1; z <= temptotalhk; z++)
                                {
                                    xoa();
                                }
                                for (int z = tempdone + 1; z <= temptotalhk; z++)
                                {
                                    them();
                                }


                            }
                        }

                        rowsToRemove.Add(row);
                    }
                }

                // Remove the selected rows from the dataGridView
                foreach (DataGridViewRow row in rowsToRemove)
                {
                    dataGridView.Rows.Remove(row);
                }

                // Clear the list
                rowsToRemove.Clear();
            });
            panel.Controls.Add(deleteButton);

            System.Windows.Forms.Button addsubject = new System.Windows.Forms.Button();
            addsubject.Text = "Thêm học phần";
            addsubject.Font = new Font("Segoe UI", 11);
            addsubject.ForeColor = Color.White;
            addsubject.BackColor = Color.FromArgb(56, 114, 178);
            addsubject.Width = 180;
            addsubject.Height = 35;
            addsubject.Location = new Point(panel.Width - 470, panel.Height - 45);
            //List<DataGridViewRow> rowsToRemove = new List<DataGridViewRow>();

            // Attach the EventHandler to the deleteButton
            addsubject.Click += new EventHandler((sender, e) =>
            {
                this.Hide();
                ThemHocPhan thp = new ThemHocPhan(subject, currenthk, this);
                thp.SelectedSubjectsSelected += Thp_SelectedSubjectsSelected;
                thp.ShowDialog();
            });
            panel.Controls.Add(addsubject);

            /*           this.Hide();
            ThemHocPhan thp = new ThemHocPhan(subject, totalhk, this);
            thp.SelectedSubjectsSelected += Thp_SelectedSubjectsSelected;
            thp.ShowDialog();*/
            dataGridView.AllowUserToAddRows = false;

            return p;
        }

        private void dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception is FormatException)
            {
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


        List<string> prevsubject = new List<string>();
        int stop = 0;
        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(stop.ToString());
            var dataGridView = (DataGridView)sender;
            if (e.ColumnIndex == dataGridView.Columns["Name"].Index)
            {
                DataGridViewComboBoxCell cell = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                if (cell.Value != null)
                {
                    string selectedName = cell.Value.ToString();
                    //    MessageBox.Show(selectedName);
                    /*
                        foreach (DataGridViewRow row2 in dataGridView.Rows)
                        {
                            if (row2.Index != e.RowIndex)
                            {
                                DataGridViewComboBoxCell otherCell = row2.Cells["Name"] as DataGridViewComboBoxCell;

                                if (otherCell != null && otherCell.Value != null)
                                {
                                    // MessageBox.Show(otherCell.Value.ToString());
                                    if (!prevsubject.Contains(otherCell.Value.ToString()))
                                    {
                                        //MessageBox.Show(otherCell.Value.ToString() + "" + dataGridView.Rows[e.RowIndex].Cells["Name"].ToString());
                                        MessageBox.Show("remvoed");
                                        prevsubject.Remove(otherCell.Value.ToString());

                                        foreach (subjects sj in subject)
                                        {
                                            if (sj.Name == selectedName)
                                            {
                                                sj.Done = 0;
                                                MessageBox.Show("a");
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        */
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
                            //MessageBox.Show(e.RowIndex.ToString() + "-" + row.Index.ToString());
                            if (row.Index == e.RowIndex)
                            {
                                //stop++;
                                DataGridViewTextBoxCell otherCelldone = row.Cells["Done"] as DataGridViewTextBoxCell;
                                if (otherCelldone != null && otherCelldone.Value != null)
                                {
                                    if (int.Parse(otherCelldone.Value.ToString()) == totalhk)
                                    {
                                        // MessageBox.Show(otherCelldone.Value.ToString() + totalhk.ToString());
                                        cell.Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Credits"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Prerequisite"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Groupz"].Value = null;
                                        dataGridView.Rows[e.RowIndex].Cells["Mandatory"].Value = null;
                                        MessageBox.Show("Môn học này đã được chọn 1", "Lưu ý");
                                        //MessageBox.Show(stop.ToString());

                                        //  dataGridView.Rows.RemoveAt(e.RowIndex+1);
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
                                        //   dataGridView.Rows[e.RowIndex].Cells["Done"].Value = null;
                                        MessageBox.Show("Môn học này đã được chọn 2", "Lưu ý");
                                        // dataGridView.Rows.RemoveAt(e.RowIndex);
                                        break;
                                    }
                                }
                            }
                        }
                        /*
                        foreach(string sj in prevsubject)
                        {
                            if (sj == selectedName)
                            {
                                // set sj.Done of previous subject to 0
                                subjects prevSelectedSubject = subject.FirstOrDefault(s => s.Name == sj);
                                if (prevSelectedSubject != null)
                                {
                                    MessageBox.Show("Môn học này đã được chọn 3", "Lưu ý");
                                    //prevSelectedSubject.Done = 0;
                                }
                                //sj = selectedName;
                            }
                        }*/
                        string[] prerequisites = selectedSubject.Prerequisite.Split(',');
                        string unsatisfiedPrerequisites = "";
                        foreach (string prerequisite in prerequisites)
                        {
                            if (!string.IsNullOrEmpty(prerequisite))
                            {
                                string prerequisiteId = prerequisite.Trim();
                                subjects prerequisiteSubject = subject.FirstOrDefault(s => s.Id == prerequisiteId/* && s.Done < totalhk-1*/);
                                if (prerequisiteSubject != null && (prerequisiteSubject.Done >= totalhk || prerequisiteSubject.Done == 0))
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
                            //  selectedSubject.Done = totalhk;

                            foreach (subjects sj in subject)
                            {
                                if (sj.Id == selectedSubject.Id)
                                {
                                    /*if (!prevsubject.Contains(sj.Name))
                                    {
                                        prevsubject.Add(sj.Name);
                                           MessageBox.Show("here 2");
                                    }*/
                                    sj.Done = totalhk;
                                    //MessageBox.Show(sj.Name + sj.Done.ToString());
                                }
                            }
                            //MessageBox.Show("here "+ selectedSubject.Done.ToString());
                        }
                    }
                }
            }
        }

        int totalhk;
        int totalhkfix;
        string currentyear = "1-1";
        studentSubjects[] studentlist0 = new studentSubjects[90];
        subjects[] subject;
        private void button1_Click(object sender, EventArgs e)
        {
            filehtml.FileName = "";
            filehtml.Filter = "Html-Files(*.html)|*.html";
            filehtml.ShowDialog(this);
            textBox1.Text = filehtml.FileName;
            if (textBox1.Text == "")
                return;
            string file = System.IO.File.ReadAllText(filehtml.FileName);

            /*
            for (int u = 0; u < 90; ++u)
            {
                studentlist0[u] = new studentSubjects();
            }

            filter.gethk(file, studentlist0);
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
            //string name = filter.getuserid(file);
            //label2.Text = name;
            // MessageBox.Show("first" + totalhk);

            */
            int total = 0;
            subject = initiateData.data(studentlist0, subject, file, ref total);
            // int newSize = 60;
            studentSubjects[] StudentList = new studentSubjects[total + 1];
            Array.Copy(studentlist0, StudentList, total + 1);
            //studentlist0 = null;
            addPanel(Int32.Parse(StudentList[0].Name), StudentList);
            totalhk = Int32.Parse(StudentList[0].Name);
            currentyear = StudentList[total].Hknamhoc;
            // MessageBox.Show(currentyear);
            totalhkfix = totalhk;
            //string name = filter.getuserid(file);
            //label2.Text = name;
            // MessageBox.Show("first" + totalhk);
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void Form2_Load(object sender, EventArgs e)
        {

            int total = 0;
            subject = initiateData.data(studentlist0, subject, "", ref total);

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

            flowLayoutPanel1.AutoScrollPosition = new Point(0, int.MaxValue);
        }

        private void them()
        {
            totalhk++;
            addPanel1(totalhk, subject);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            string dataGridViewName = "dataz" + totalhk;
            Control dataGridViewControl = flowLayoutPanel1.Controls.Find(dataGridViewName, false).FirstOrDefault();

            if (dataGridViewControl != null && dataGridViewControl is DataGridView)
            {
                DataGridView dataGridView = (DataGridView)dataGridViewControl;

                if (dataGridView.Rows.Count > 0)
                {
                    MessageBox.Show("Vui lòng xóa hết dữ liệu trước khi xóa học kỳ");
                }
                else
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

        private void Thp_SelectedSubjectsSelected(object sender, List<string> selectedSubjects, int currenthk)
        {
            foreach (string st in selectedSubjects)
            {
                foreach (subjects sj in subject)
                {
                    if (sj.Id == st)
                    {
                        // MessageBox.Show(sj.Id);
                        sj.Done = currenthk;
                        // sj.Mandatory = st.man






                        if (!prevsubject.Contains(sj.Name))
                        {
                            prevsubject.Add(sj.Name);

                        }
                    }
                }
            }
            int temptotalhk = totalhk;
            ////int tempdone = sj.Done;
            //  sj.Done = 0;
            for (int z = currenthk; z <= temptotalhk; z++)
            {
                xoa();
            }

            them();
            flowLayoutPanel1.AutoScrollPosition = new Point(0, int.MaxValue);
            for (int z = currenthk + 1; z <= temptotalhk; z++)
            {
                them();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            ThemHocPhan thp = new ThemHocPhan(subject, totalhk, this);
            thp.SelectedSubjectsSelected += Thp_SelectedSubjectsSelected;
            thp.ShowDialog();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            // MessageBox.Show(Mssv.ToString());
            foreach (studentSubjects st in studentlist0)
            {
                st.St_id = Mssv;
            }
            addStudentSujecttoDB add = new addStudentSujecttoDB();
            add.addstudent(studentlist0);
            add.UpdateHk(Mssv, totalhkfix);
            MessageBox.Show("Đã lưu vào cơ sở dữ liệu");

        }

        private void button6_Click(object sender, EventArgs e)
        {
            studentSubjects[] studentlist1 = new studentSubjects[90];
            getbangdiem gea = new getbangdiem();
            studentlist1 = gea.GetStudentSubjects(Mssv);
            if (studentlist1 != null)
            /*  for (int i = totalhkfix; i<totalhk; i++)
              {
                  totalhkfix++;
                  addPanel1(totalhkfix, subject);
                  flowLayoutPanel1.AutoScrollPosition = new Point(0, int.MaxValue);
              }*/
            {
                addPanel(Int32.Parse(studentlist1[0].Name), studentlist1);
                totalhk = Int32.Parse(studentlist1[0].Name);
                studentlist0 = studentlist1;
            }
            else MessageBox.Show("Không có dữ liệu trùng khớp với mã sinh viên");
        }

        private void btnthemhk_Click(object sender, EventArgs e)
        {
            if (totalhk >= 27)
            {
                MessageBox.Show("Đã vượt học kỳ cho phép");
                return;
            }

            them();

            flowLayoutPanel1.AutoScrollPosition = new Point(0, int.MaxValue);
        }
    }
}
