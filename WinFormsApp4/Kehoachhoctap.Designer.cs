using System.Windows.Forms;

namespace WinFormsApp4
{
    partial class Kehoachhoctap
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Kehoachhoctap));
            button1 = new Button();
            filehtml = new OpenFileDialog();
            textBox1 = new TextBox();
            panel1 = new Panel();
            userinfor = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            label2 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel2 = new Panel();
            label6 = new Label();
            gpacal = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            currentgpa = new Label();
            earnedcredits = new Label();
            currentcredit = new Label();
            btnredhk = new Button();
            btnthemhk = new Button();
            button6 = new Button();
            button4 = new Button();
            button3 = new Button();
            bordera = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            bordera.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(958, 33);
            button1.Name = "button1";
            button1.Size = new Size(142, 52);
            button1.TabIndex = 0;
            button1.Text = "Tải file";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(642, 50);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(310, 27);
            textBox1.TabIndex = 1;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(userinfor);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(button1);
            panel1.Location = new Point(6, 4);
            panel1.Margin = new Padding(20);
            panel1.Name = "panel1";
            panel1.Size = new Size(1572, 106);
            panel1.TabIndex = 5;
            panel1.Paint += panel1_Paint;
            // 
            // userinfor
            // 
            userinfor.AutoSize = true;
            userinfor.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            userinfor.Location = new Point(1144, 4);
            userinfor.Name = "userinfor";
            userinfor.Size = new Size(104, 23);
            userinfor.TabIndex = 5;
            userinfor.Text = "place holder";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(115, 13);
            label1.Name = "label1";
            label1.Size = new Size(521, 81);
            label1.TabIndex = 2;
            label1.Text = "Kế hoạch học tập";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(1119, 4);
            label2.Name = "label2";
            label2.Size = new Size(0, 23);
            label2.TabIndex = 3;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(5, 3);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1335, 716);
            flowLayoutPanel1.TabIndex = 6;
            flowLayoutPanel1.Scroll += flowLayoutPanel1_Scroll;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            flowLayoutPanel1.MouseWheel += flowLayoutPanel1_MouseWheel;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(label6);
            panel2.Controls.Add(gpacal);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(currentgpa);
            panel2.Controls.Add(earnedcredits);
            panel2.Controls.Add(currentcredit);
            panel2.Controls.Add(btnredhk);
            panel2.Controls.Add(btnthemhk);
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Location = new Point(1357, 113);
            panel2.Name = "panel2";
            panel2.Size = new Size(221, 731);
            panel2.TabIndex = 7;
            panel2.Paint += panel2_Paint;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(10, 152);
            label6.Name = "label6";
            label6.Size = new Size(173, 92);
            label6.TabIndex = 16;
            label6.Text = "Để đạt được loại \r\nxuất sắt/giỏi/ khá\r\ncác môn còn lại phải \r\nlớn hơn hoặc bằng:";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // gpacal
            // 
            gpacal.AutoSize = true;
            gpacal.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            gpacal.Location = new Point(39, 266);
            gpacal.Name = "gpacal";
            gpacal.Size = new Size(27, 23);
            gpacal.TabIndex = 15;
            gpacal.Text = "ec";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(10, 99);
            label5.Name = "label5";
            label5.Size = new Size(108, 23);
            label5.TabIndex = 14;
            label5.Text = "GPA hiện tại:";
            label5.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(6, 60);
            label4.Name = "label4";
            label4.Size = new Size(175, 23);
            label4.TabIndex = 13;
            label4.Text = "Số tín chỉ hoàn thành";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(10, 25);
            label3.Name = "label3";
            label3.Size = new Size(141, 23);
            label3.TabIndex = 12;
            label3.Text = "Số tín chỉ dự tính";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // currentgpa
            // 
            currentgpa.AutoSize = true;
            currentgpa.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentgpa.Location = new Point(174, 99);
            currentgpa.Name = "currentgpa";
            currentgpa.Size = new Size(28, 23);
            currentgpa.TabIndex = 7;
            currentgpa.Text = "cg";
            // 
            // earnedcredits
            // 
            earnedcredits.AutoSize = true;
            earnedcredits.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            earnedcredits.Location = new Point(180, 60);
            earnedcredits.Name = "earnedcredits";
            earnedcredits.Size = new Size(27, 23);
            earnedcredits.TabIndex = 6;
            earnedcredits.Text = "ec";
            // 
            // currentcredit
            // 
            currentcredit.AutoSize = true;
            currentcredit.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            currentcredit.Location = new Point(179, 25);
            currentcredit.Name = "currentcredit";
            currentcredit.Size = new Size(26, 23);
            currentcredit.TabIndex = 6;
            currentcredit.Text = "cc";
            currentcredit.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnredhk
            // 
            btnredhk.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnredhk.Location = new Point(14, 481);
            btnredhk.Name = "btnredhk";
            btnredhk.Size = new Size(191, 52);
            btnredhk.TabIndex = 11;
            btnredhk.Text = "Thêm theo mẫu";
            btnredhk.UseVisualStyleBackColor = true;
            btnredhk.Click += btnredhk_Click;
            // 
            // btnthemhk
            // 
            btnthemhk.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            btnthemhk.Location = new Point(39, 322);
            btnthemhk.Name = "btnthemhk";
            btnthemhk.Size = new Size(142, 52);
            btnthemhk.TabIndex = 10;
            btnthemhk.Text = "Thêm HK";
            btnthemhk.UseVisualStyleBackColor = true;
            btnthemhk.Click += btnthemhk_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button6.Location = new Point(39, 649);
            button6.Name = "button6";
            button6.Size = new Size(142, 52);
            button6.TabIndex = 9;
            button6.Text = "Tải";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button4.Location = new Point(39, 567);
            button4.Name = "button4";
            button4.Size = new Size(142, 52);
            button4.TabIndex = 8;
            button4.Text = "Lưu";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click_1;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            button3.Location = new Point(39, 396);
            button3.Name = "button3";
            button3.Size = new Size(142, 52);
            button3.TabIndex = 5;
            button3.Text = "Xóa HK";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // bordera
            // 
            bordera.BorderStyle = BorderStyle.FixedSingle;
            bordera.Controls.Add(flowLayoutPanel1);
            bordera.Location = new Point(6, 113);
            bordera.Name = "bordera";
            bordera.Size = new Size(1345, 731);
            bordera.TabIndex = 8;
            bordera.Paint += bordera_Paint;
            // 
            // Kehoachhoctap
            // 
            AutoScaleMode = AutoScaleMode.None;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = SystemColors.InactiveBorder;
            ClientSize = new Size(1582, 853);
            Controls.Add(bordera);
            Controls.Add(panel2);
            Controls.Add(panel1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Kehoachhoctap";
            Text = "Form2";
            Load += Form2_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            bordera.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private OpenFileDialog filehtml;
        private TextBox textBox1;

        private Panel panel1;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Panel panel2;

        private Panel bordera;
        private Button button3;
        private Label label2;
        private PictureBox pictureBox1;
        private Button button4;
        private Button button6;
        private Button btnthemhk;
        private Button btnredhk;
        private Label userinfor;
        private Label currentcredit;
        private Label currentgpa;
        private Label earnedcredits;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label6;
        private Label gpacal;
    }
}