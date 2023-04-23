namespace WinFormsApp4
{
    partial class RegisterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox4 = new TextBox();
            label4 = new Label();
            btnBack = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(203, 175);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 27);
            textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(203, 220);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(188, 27);
            textBox2.TabIndex = 1;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(272, 362);
            button1.Name = "button1";
            button1.Size = new Size(143, 50);
            button1.TabIndex = 2;
            button1.Text = "Xác nhận";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(203, 303);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(188, 27);
            textBox3.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(29, 177);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 4;
            label1.Text = "MSSV:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(28, 222);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 5;
            label2.Text = "Mật khẩu:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(29, 302);
            label3.Name = "label3";
            label3.Size = new Size(94, 25);
            label3.TabIndex = 6;
            label3.Text = "Họ và Tên";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(203, 263);
            textBox4.Name = "textBox4";
            textBox4.PasswordChar = '*';
            textBox4.Size = new Size(188, 27);
            textBox4.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(27, 262);
            label4.Name = "label4";
            label4.Size = new Size(170, 25);
            label4.TabIndex = 8;
            label4.Text = "Nhập lại mật khẩu:";
            // 
            // btnBack
            // 
            btnBack.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnBack.Location = new Point(27, 362);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(205, 47);
            btnBack.TabIndex = 9;
            btnBack.Text = "Trở về đăng nhập";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(184, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // RegisterForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(470, 465);
            Controls.Add(pictureBox1);
            Controls.Add(btnBack);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "RegisterForm";
            Text = "RegisterForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox4;
        private Label label4;
        private Button btnBack;
        private PictureBox pictureBox1;
    }
}