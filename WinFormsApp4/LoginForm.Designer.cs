namespace WinFormsApp4
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            label2 = new Label();
            label1 = new Label();
            btnLog = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            btnRes = new Button();
            pictureBox1 = new PictureBox();
            chkShowpas = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(19, 202);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 14;
            label2.Text = "Mật khẩu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(19, 142);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 13;
            label1.Text = "MSSV:";
            // 
            // btnLog
            // 
            btnLog.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnLog.Location = new Point(200, 284);
            btnLog.Name = "btnLog";
            btnLog.Size = new Size(142, 52);
            btnLog.TabIndex = 11;
            btnLog.Text = "Đăng nhập";
            btnLog.UseVisualStyleBackColor = true;
            btnLog.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(130, 200);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(188, 27);
            textBox2.TabIndex = 10;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(130, 140);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(188, 27);
            textBox1.TabIndex = 9;
            // 
            // btnRes
            // 
            btnRes.Font = new Font("Segoe UI", 13F, FontStyle.Bold, GraphicsUnit.Point);
            btnRes.Location = new Point(29, 284);
            btnRes.Name = "btnRes";
            btnRes.Size = new Size(142, 52);
            btnRes.TabIndex = 15;
            btnRes.Text = "Đăng ký";
            btnRes.UseVisualStyleBackColor = true;
            btnRes.Click += button2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(141, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 100);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // chkShowpas
            // 
            chkShowpas.AutoSize = true;
            chkShowpas.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            chkShowpas.Location = new Point(130, 249);
            chkShowpas.Name = "chkShowpas";
            chkShowpas.Size = new Size(156, 29);
            chkShowpas.TabIndex = 19;
            chkShowpas.Text = "Hiện mật khẩu";
            chkShowpas.UseVisualStyleBackColor = true;
            chkShowpas.CheckedChanged += chkShowpas_CheckedChanged;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(382, 423);
            Controls.Add(chkShowpas);
            Controls.Add(pictureBox1);
            Controls.Add(btnRes);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnLog);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Name = "LoginForm";
            Text = "LoginForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private Label label1;
        private Button btnLog;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button btnRes;
        private PictureBox pictureBox1;
        private CheckBox chkShowpas;
    }
}