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
        public ThemHocPhan(subjects[] subject, int totalhk, Form formkh)
        {
            this.totalhk = totalhk;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.form = formkh;
            InitializeComponent();
            this.subject = subject;


            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn()
            { HeaderText = "Select", DataPropertyName = "Selected", Name = "Selected" });
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            dataGridView1.Columns.Add("Id", "Mã học phần");
            dataGridView1.Columns.Add("Name", "Tên học phần");
            dataGridView1.Columns.Add("Credits", "Tín chỉ");
            dataGridView1.Columns.Add("Prerequisite", "Tiên quyết");
            dataGridView1.Columns.Add("Groupz", "Nhóm");
            dataGridView1.Columns.Add("Mandatory", "Bắt buộc");
            dataGridView1.Columns.Add("Done", "Done");
            dataGridView1.Columns.Add("Recommend", "Học kỳ theo mẫu");
            dataGridView1.Columns.Add("Opentime", "Học kỳ mở");
            dataGridView1.Columns["Id"].DataPropertyName = "Id";
            dataGridView1.Columns["Name"].DataPropertyName = "Name";
            dataGridView1.Columns["Credits"].DataPropertyName = "Credits";
            dataGridView1.Columns["Prerequisite"].DataPropertyName = "Prerequisite";
            dataGridView1.Columns["Groupz"].DataPropertyName = "Groupz";
            dataGridView1.Columns["Mandatory"].DataPropertyName = "Mandatory";
            dataGridView1.Columns["Done"].DataPropertyName = "Done";
            dataGridView1.Columns["Recommend"].DataPropertyName = "Recommend";
            dataGridView1.Columns["Opentime"].DataPropertyName = "Opentime";
            dataGridView1.Columns["Id"].Width = 80;
            dataGridView1.Columns["Name"].Width = 120;
            dataGridView1.Columns["Credits"].Width = 80;
            dataGridView1.Columns["Prerequisite"].Width = 120;
            dataGridView1.Columns["Groupz"].Width = 120;
            dataGridView1.Columns["Mandatory"].Width = 100;
            dataGridView1.Columns["Done"].Width = 50;
            dataGridView1.Columns["Recommend"].Width = 50;
            dataGridView1.Columns["Opentime"].Width = 50;

            var filteredList2 = subject.Where(s => (s.Mandatory != "0") && (s.Done == 0)).OrderBy(s => s.Recommend).ToArray();

            dataGridView1.DataSource = filteredList2;
            dataGridView1.BackgroundColor = Color.White;
            this.BackColor = Color.FromArgb(240, 244, 252);

        }
        string[] unsat = new string[] { };
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex == dataGridView1.Columns["Selected"].Index)
            {
                var dataGridView1 = (DataGridView)sender;
                DataGridViewCheckBoxCell chk = dataGridView1.Rows[e.RowIndex].Cells["Selected"] as DataGridViewCheckBoxCell;

                //DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[1];

                /* if (chkCell.Value == chkCell.FalseValue)
                {
                    MessageBox.Show("qwe");
                    return;
                }*/

                var selectedSubject = dataGridView1.Rows[e.RowIndex].DataBoundItem as subjects;

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
                    // chk.Value = chk.FalseValue;
                    //dataGridView1.Rows[e.RowIndex].Cells["Selected"].Selected = false;
                    //MessageBox.Show(target);
                    MessageBox.Show(string.Format("Môn học {0} - {1} chưa đáp ứng điều kiện tiên quyết:\n{2}",
                                selectedSubject.Id, selectedSubject.Name, unsatisfiedPrerequisites));
                }

            }

        }

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





        List<string> selectedSubjects;
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UncheckRowsWithUnsatisfiedPrerequisites(unsat);
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
            SelectedSubjectsSelected?.Invoke(this, selectedSubjects);
            this.Close();
            form.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            UncheckRowsWithUnsatisfiedPrerequisites(unsat);
        }

        public delegate void SelectedSubjectsEventHandler(object sender, List<string> selectedSubjects);

        public event SelectedSubjectsEventHandler SelectedSubjectsSelected;



    }
}
