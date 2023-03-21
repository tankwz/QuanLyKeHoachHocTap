namespace WinFormsApp4
{
    partial class ToanBoHocPhan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.credits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prerequisite = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mandatory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(974, 159);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.credits,
            this.prerequisite,
            this.mandatory,
            this.groupz});
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.Size = new System.Drawing.Size(1157, 571);
            this.dataGridView1.TabIndex = 2;
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "Mã học phần";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.Width = 125;
            // 
            // name
            // 
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Tên học phần";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 300;
            // 
            // credits
            // 
            this.credits.DataPropertyName = "credits";
            this.credits.HeaderText = "Tín chỉ";
            this.credits.MinimumWidth = 6;
            this.credits.Name = "credits";
            this.credits.Width = 125;
            // 
            // prerequisite
            // 
            this.prerequisite.DataPropertyName = "prerequisite";
            this.prerequisite.HeaderText = "Tiên quyết";
            this.prerequisite.MinimumWidth = 6;
            this.prerequisite.Name = "prerequisite";
            this.prerequisite.Width = 125;
            // 
            // mandatory
            // 
            this.mandatory.DataPropertyName = "mandatory";
            this.mandatory.HeaderText = "Bắt buộc";
            this.mandatory.MinimumWidth = 6;
            this.mandatory.Name = "mandatory";
            this.mandatory.Width = 125;
            // 
            // groupz
            // 
            this.groupz.DataPropertyName = "groupz";
            this.groupz.HeaderText = "Nhóm";
            this.groupz.MinimumWidth = 6;
            this.groupz.Name = "groupz";
            this.groupz.Width = 125;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 272);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1129, 579);
            this.panel1.TabIndex = 3;
            // 
            // ToanBoHocPhan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 853);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "ToanBoHocPhan";
            this.Text = "ToanBoHocPhan";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Button button1;
        private DataGridView dataGridView1;
        private Panel panel1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn credits;
        private DataGridViewTextBoxColumn prerequisite;
        private DataGridViewTextBoxColumn mandatory;
        private DataGridViewTextBoxColumn groupz;
    }
}