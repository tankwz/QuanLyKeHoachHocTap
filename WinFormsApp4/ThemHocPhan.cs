using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace WinFormsApp4
{
    public partial class ThemHocPhan : Form
    {
        private subjects[] subject;
        int totalhk;
        Form form = new Form();
        int totalcre;
        public ThemHocPhan(subjects[] subject, int totalhk, Form formkh, int totalcre)
        {
            this.totalhk = totalhk;
            this.totalcre = totalcre;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.form = formkh;
            InitializeComponent();
            this.subject = subject;
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            { HeaderText = "Select", DataPropertyName = "Selected", Name = "Selected", Width = 55 });
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            dataGridView1.Columns.Add("Id", "Mã học phần");
            dataGridView1.Columns.Add("Name", "Tên học phần");
            dataGridView1.Columns.Add("Credits", "Tín chỉ");
            dataGridView1.Columns.Add("Prerequisite", "Tiên quyết");
            dataGridView1.Columns.Add("Groupz", "Nhóm");
            // dataGridView1.Columns.Add("Mandatory", "Bắt buộc");
            //dataGridView1.Columns.Add("Done", "Done");
            dataGridView1.Columns.Add("Recommend", "Học kỳ theo mẫu");
            dataGridView1.Columns.Add("Opentime", "Học kỳ mở");
            dataGridView1.Columns["Id"].DataPropertyName = "Id";
            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Credits"].DataPropertyName = "Credits";
            dataGridView1.Columns["Prerequisite"].DataPropertyName = "Prerequisite";
            dataGridView1.Columns["Groupz"].DataPropertyName = "Groupz";
            // dataGridView1.Columns["Mandatory"].DataPropertyName = "Mandatory";
            //dataGridView1.Columns["Done"].DataPropertyName = "Done";
            dataGridView1.Columns["Recommend"].DataPropertyName = "Recommend";
            dataGridView1.Columns["Opentime"].DataPropertyName = "Opentime";
            dataGridView1.Columns["Id"].Width = 100;
            dataGridView1.Columns["Name"].Width = 340;
            dataGridView1.Columns["Credits"].Width = 80;
            dataGridView1.Columns["Prerequisite"].Width = 120;
            dataGridView1.Columns["Groupz"].Width = 70;
            //    dataGridView1.Columns["Mandatory"].Width = 80;
            // dataGridView1.Columns["Done"].Width = 50;
            dataGridView1.Columns["Recommend"].Width = 240;
            dataGridView1.Columns["Opentime"].Width = 100;
            currentCredits.Text = totalcre.ToString();
            //var filteredList2 = subject.Where(s => (s.Mandatory != "0") && (s.Done == 0) && (s.Mandatory >0)).OrderBy(s => s.Recommend).ToArray();
            dataGridView1.AutoGenerateColumns = false;
            var filteredList2 = subject
    .Where(s => (s.Done == 0) && (s.Mandatory == "all" || (int.TryParse(s.Mandatory, out int mandatoryValue) && mandatoryValue > 0)))
    .OrderBy(s => s.Recommend)
    .ToArray();

            //  ApplyCellFormatting(filteredList2, subject, totalhk);



            dataGridView1.DataSource = filteredList2;
            dataGridView1.BackgroundColor = Color.White;
            this.BackColor = Color.FromArgb(240, 244, 252);
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            //  dataGridView1.CellFormatting += (sender, e) => dataGridView1_CellFormatting(sender, e, filteredList2);


        }
        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            var dataGridView1 = (DataGridView)sender;
            var selectedSubject = (subjects)dataGridView1.Rows[e.RowIndex].DataBoundItem;

            if (selectedSubject != null)
            {
                if (e.ColumnIndex == dataGridView1.Columns["Opentime"].Index)
                {
                    int opentime = (int)e.Value;
                    string displayValue = GetOpentimeDisplay(opentime);
                    e.Value = displayValue;
                }
                else if (e.ColumnIndex == dataGridView1.Columns["Recommend"].Index)
                {
                    int recommendValue = (int)e.Value;
                    string displayValue = GetRecommendDisplay(recommendValue);
                    e.Value = displayValue;
                }

                if (selectedSubject.Recommend < totalhk)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }

                if (!string.IsNullOrEmpty(selectedSubject.Prerequisite))
                {
                    string[] prerequisites = selectedSubject.Prerequisite.Split(',');
                    foreach (string prerequisite in prerequisites)
                    {
                        if (!string.IsNullOrEmpty(prerequisite))
                        {
                            string prerequisiteId = prerequisite.Trim();
                            subjects prerequisiteSubject = subject.FirstOrDefault(s => s.Id == prerequisiteId);
                            if (prerequisiteSubject != null && (prerequisiteSubject.Done >= totalhk || prerequisiteSubject.Done == 0))
                            {
                                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                                break;
                            }
                        }
                    }
                }
                else if ((selectedSubject.Opentime == 2 && totalhk % 3 == 0))
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else if (selectedSubject.Recommend == totalhk)
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                }

            }
        }

        /*
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e, subjects[] filteredList)
        {

            var dataGridView1 = (DataGridView)sender;
            if (e.ColumnIndex == dataGridView1.Columns["Opentime"].Index && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    int opentime = (int)cell.Value;
                    string displayValue = GetOpentimeDisplay(opentime);
                    e.Value = displayValue;
                }
            }
            if (e.ColumnIndex == dataGridView1.Columns["Recommend"].Index && e.RowIndex >= 0)
            {
                DataGridViewCell cell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell.Value != null)
                {
                    int recommendValue = (int)cell.Value;
                    string displayValue = GetRecommendDisplay(recommendValue);
                    e.Value = displayValue;
                }
            }

            foreach (var sj in filteredList)
            {
                var selectedSubject = sj;
                //MessageBox.Show("s");
                if ((selectedSubject.Opentime == 2 && totalhk % 3 == 0))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString() == selectedSubject.Id)
                        {
                            // MessageBox.Show(sj.Id);
                            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Gray;
                            //   row.DefaultCellStyle.BackColor = Color.Red;
                            break;
                        }
                    }
                }
                if ((selectedSubject.Recommend == totalhk))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString() == selectedSubject.Id)
                        {
                            // MessageBox.Show(sj.Id);
                            dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.LightBlue;
                            //   row.DefaultCellStyle.BackColor = Color.Red;
                            break; // Exit the loop once the row is found
                        }
                    }
                }
                if (string.IsNullOrEmpty(sj.Prerequisite))
                    continue;
                //var selectedSubject = sj;

                string[] prerequisites = selectedSubject.Prerequisite.Split(',');
                //MessageBox.Show("s");
                foreach (string prerequisite in prerequisites)
                {
                    if (!string.IsNullOrEmpty(prerequisite))
                    {
                        string prerequisiteId = prerequisite.Trim();
                        subjects prerequisiteSubject = subject.FirstOrDefault(s => s.Id == prerequisiteId);
                        if ((prerequisiteSubject != null && (prerequisiteSubject.Done >= totalhk || prerequisiteSubject.Done == 0)))
                        {
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString() == sj.Id)
                                {
                                    // MessageBox.Show(sj.Id);
                                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Red;
                                    //   row.DefaultCellStyle.BackColor = Color.Red;
                                    break; // Exit the loop once the row is found
                                }
                            }
                        }
                    }
                }
            }

            // Unsubscribe from the event after executing the code once
            dataGridView1.CellFormatting -= (s, args) => dataGridView1_CellFormatting(s, args, filteredList);
        //    dataGridView1.CellFormatting -= (s, args) => dataGridView1_CellFormatting(s, args, filteredList);
        }
        */
        private Semester semester = new Semester();
        private string GetRecommendDisplay(int recommendValue)
        {
            if (semester.Semesterk44ktmp.ContainsKey(recommendValue))
            {
                return semester.Semesterk44ktmp[recommendValue];
            }
            else
            {
                return string.Empty;
            }
        }
        private string GetOpentimeDisplay(int opentime)
        {
            switch (opentime)
            {
                case 0:
                    return "Sắp sẵn";
                case 1:
                    return "III";
                case 2:
                    return "I, II";
                case 3:
                    return "I, II, III";
                default:
                    return string.Empty;
            }
        }
        string[] unsat = new string[] { };
        // int totalcre = 0;
        string checksub = "";
        string checksubmand = "";

        bool koadd = false;
        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Selected"].Index)
            {
                var dataGridView1 = (DataGridView)sender;
                DataGridViewCheckBoxCell chk = dataGridView1.Rows[e.RowIndex].Cells["Selected"] as DataGridViewCheckBoxCell;
                var selectedSubject = dataGridView1.Rows[e.RowIndex].DataBoundItem as subjects;


                if (chk.Value != null && (bool)chk.Value == true)
                {

                    if (selectedSubject.Opentime == 2 && totalhk % 3 == 0)
                    {
                        MessageBox.Show("Môn học " + selectedSubject.Name + " không mở vào học kỳ hè");
                        chk.Value = false;
                        //  return;
                    }

                    /* if (totalcre <= 20 && totalhk % 3 != 0)
                     {
                         totalcre += selectedSubject.Credits;

                     }*/
                    if (totalhk % 3 != 0)
                    {
                        if (totalhk < 13 && totalcre <= 20)
                        {
                            totalcre += selectedSubject.Credits;
                        }
                        else if (totalhk >= 13 && totalcre <= 25)
                        {
                            totalcre += selectedSubject.Credits;
                        }
                    }
                    if (totalhk % 3 != 0)
                    {
                        if (totalhk < 13 && totalcre > 20)
                        {
                            MessageBox.Show("Học kỳ không được vượt quá 20 tín chỉ");
                            chk.Value = false;
                        }
                        else if (totalhk >= 13 && totalcre > 25)
                        {
                            MessageBox.Show("Học kỳ không được vượt quá 25 tín chỉ");
                            chk.Value = false;
                        }
                    }
                    if (totalcre <= 8 && totalhk % 3 == 0)
                    {
                        totalcre += selectedSubject.Credits;
                    }
                    if (totalcre > 8 && totalhk % 3 == 0)
                    {
                        MessageBox.Show("Học kỳ hè không được vượt quá 8 tín chỉ");
                        chk.Value = false;
                    }
                    koadd = false;
                    //////////////////////////
                    if (!string.IsNullOrEmpty(selectedSubject.Groupz))
                    {


                        string firstTwo = selectedSubject.Groupz.Substring(0, 2);
                        string lastTwo = string.Empty;

                        if (selectedSubject.Groupz.Length > 2)
                            lastTwo = selectedSubject.Groupz.Substring(2, 2);

                        // Iterate over the DataGridView rows
                        if (!string.IsNullOrEmpty(lastTwo))
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                if (row.Index == e.RowIndex)
                                {

                                    continue;
                                }
                                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Selected"] as DataGridViewCheckBoxCell;
                                if (checkBoxCell.Value == null || !(bool)checkBoxCell.Value)
                                    continue;

                                // Compare the group of the checked row with the group of the clicked subject
                                subjects checkedSubject = row.DataBoundItem as subjects;
                                if (checkedSubject != null && checkedSubject.Groupz.StartsWith(firstTwo))
                                {
                                    string checkedLastTwo = checkedSubject.Groupz.Substring(2, 2);
                                    if (lastTwo != checkedLastTwo)
                                    {
                                        koadd = true;
                                        chk.Value = false;
                                        //   koadd = false;
                                        //   MessageBox.Show(checksubmand);
                                        MessageBox.Show("Học phần nằm cùng nhóm " + checkedSubject.Id.ToString() + " - " + checkedSubject.Name.ToString() + "đã được chọn", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                                    }
                                }
                            }

                        if (!string.IsNullOrEmpty(lastTwo) && !koadd)
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                subjects checkedSubject = row.DataBoundItem as subjects;
                                if (checkedSubject != null && checkedSubject.Groupz.StartsWith(firstTwo))
                                {
                                    string checkedLastTwo = checkedSubject.Groupz.Substring(2, 2);
                                    if (lastTwo != checkedLastTwo)
                                    {
                                        checkedSubject.Mandatory = "0";
                                    }

                                }

                            }
                        /*     if (!string.IsNullOrEmpty(lastTwo))
                                 foreach (DataGridViewRow row in dataGridView1.Rows)
                                 {

                                     subjects checkedSubject = row.DataBoundItem as subjects;
                                     if (checkedSubject != null && checkedSubject.Id == checksub )
                                     {

                                         checkedSubject.Mandatory = checksubmand;
                                     }

                                 }
                             */

                        bool showMessage = true;

                        if (string.IsNullOrEmpty(lastTwo))
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Selected"] as DataGridViewCheckBoxCell;

                                subjects checkedSubject = row.DataBoundItem as subjects;

                                if (checkedSubject != null && checkedSubject.Groupz.StartsWith(firstTwo))
                                {
                                    //string checkedLastTwo = checkedSubject.Groupz.Substring(2, 2);
                                    if (int.Parse(checkedSubject.Mandatory) <= 0)
                                    {
                                        chk.Value = false;

                                        MessageBox.Show("Không thể thêm nữa");

                                    }
                                    checkedSubject.Mandatory = (int.Parse(checkedSubject.Mandatory) - selectedSubject.Credits).ToString();

                                    if (int.Parse(checkedSubject.Mandatory) <= 0)
                                    {
                                        if (showMessage)
                                        {
                                            MessageBox.Show("Đã đủ số tín chỉ thuộc nhóm này");
                                            showMessage = false; // Set the flag to false to prevent multiple message boxes
                                        }


                                    }
                                }
                            }
                    }
                    /////////////////////
                    string[] prerequisites = selectedSubject.Prerequisite.Split(',');
                    //MessageBox.Show("s");
                    string unsatisfiedPrerequisites = "";
                    foreach (string prerequisite in prerequisites)
                    {
                        if (!string.IsNullOrEmpty(prerequisite))
                        {
                            string prerequisiteId = prerequisite.Trim();
                            subjects prerequisiteSubject = subject.FirstOrDefault(s => s.Id == prerequisiteId);
                            if (prerequisiteSubject != null && (prerequisiteSubject.Done >= totalhk || prerequisiteSubject.Done == 0))
                            {
                                unsatisfiedPrerequisites += string.Format("{0} - {1}\n", prerequisiteId, prerequisiteSubject.Name);
                                Array.Resize(ref unsat, unsat.Length + 1);
                                unsat[unsat.Length - 1] = selectedSubject.Id;
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(unsatisfiedPrerequisites))
                    {
                        chk.Value = false;
                        MessageBox.Show(string.Format("Môn học {0} - {1} chưa đáp ứng điều kiện tiên quyết:\n{2}",
                                    selectedSubject.Id, selectedSubject.Name, unsatisfiedPrerequisites));
                        //   return;
                    }
                }
                else
                {
                    totalcre -= selectedSubject.Credits;
                    /*if (selectedSubject.Opentime == 2 && totalhk % 3 == 0)
                    {
                        totalcre += selectedSubject.Credits;
                    }*/
                    if (!string.IsNullOrEmpty(selectedSubject.Groupz))
                    {
                        string firstTwo = selectedSubject.Groupz.Substring(0, 2);
                        string lastTwo = string.Empty;

                        if (selectedSubject.Groupz.Length > 2)
                            lastTwo = selectedSubject.Groupz.Substring(2, 2);

                        // Iterate over the DataGridView rows
                        //////////////////////////
                        if (!string.IsNullOrEmpty(lastTwo))
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Selected"] as DataGridViewCheckBoxCell;

                                // Compare the group of the checked row with the group of the clicked subject
                                subjects checkedSubject = row.DataBoundItem as subjects;
                                if (checkedSubject != null && checkedSubject.Groupz.StartsWith(firstTwo))
                                {
                                    string checkedLastTwo = checkedSubject.Groupz.Substring(2, 2);
                                    if (lastTwo != checkedLastTwo)
                                    {
                                        //   MessageBox.Show(selectedSubject.Name);
                                        if (int.Parse(selectedSubject.Mandatory) > 0)
                                            checkedSubject.Mandatory = selectedSubject.Mandatory;

                                    }
                                }
                            }

                        //    koadd = false;

                        /////////////////////////
                        if (string.IsNullOrEmpty(lastTwo))
                            foreach (DataGridViewRow row in dataGridView1.Rows)
                            {
                                DataGridViewCheckBoxCell checkBoxCell = row.Cells["Selected"] as DataGridViewCheckBoxCell;

                                subjects checkedSubject = row.DataBoundItem as subjects;
                                if (checkedSubject != null && checkedSubject.Groupz.StartsWith(firstTwo))
                                {
                                    //string checkedLastTwo = checkedSubject.Groupz.Substring(2, 2);
                                    checkedSubject.Mandatory = (int.Parse(checkedSubject.Mandatory) + selectedSubject.Credits).ToString();
                                }

                            }
                    }
                    //  checksub = "";
                    //  checksubmand = "";

                }
            }
            currentCredits.Text = totalcre.ToString();
        }
        /*
        private void UncheckRowsWithUnsatisfiedPrerequisites(string[] unsat)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (unsat.Contains(row.Cells["Id"].Value.ToString()))
                {
                    DataGridViewCheckBoxCell chk = row.Cells["Selected"] as DataGridViewCheckBoxCell;
                    chk.Value = chk.FalseValue;
                }
            }
        }
        */




        List<string> selectedSubjects;


        private void button5_Click(object sender, EventArgs e)
        {
            //UncheckRowsWithUnsatisfiedPrerequisites(unsat);
            selectedSubjects = new List<string>();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                var selectedCell = row.Cells["Selected"];
                if (selectedCell != null && selectedCell.Value != null && (bool)selectedCell.Value)
                {
                    var idCell = row.Cells["Id"];
                    if (idCell != null && idCell.Value != null)
                    {
                        string subjectId = idCell.Value.ToString();
                        selectedSubjects.Add(subjectId);
                    }
                }
            }
            SelectedSubjectsSelected?.Invoke(this, selectedSubjects, totalhk);
            this.Close();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // UncheckRowsWithUnsatisfiedPrerequisites(unsat);
        }

        public delegate void SelectedSubjectsEventHandler(object sender, List<string> selectedSubjects, int totalhk);

        public event SelectedSubjectsEventHandler SelectedSubjectsSelected;



    }
}
