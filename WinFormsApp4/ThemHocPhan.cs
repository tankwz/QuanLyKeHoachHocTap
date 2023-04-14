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
        public ThemHocPhan(subjects[] subject)
        {
            InitializeComponent();
            this.subject = subject;
        }
        List<string> selectedSubjects;
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add(new DataGridViewCheckBoxColumn() { HeaderText = "Select", DataPropertyName = "Selected", Name = "Selected" });

            var filteredList2 = subject.Where(s => (s.Mandatory != "0") && (s.Done != 1)).ToArray();
            dataGridView1.DataSource = filteredList2;
        }

        private void button5_Click(object sender, EventArgs e)
        {

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
        }

        public delegate void SelectedSubjectsEventHandler(object sender, List<string> selectedSubjects);

        public event SelectedSubjectsEventHandler SelectedSubjectsSelected;



    }
}
