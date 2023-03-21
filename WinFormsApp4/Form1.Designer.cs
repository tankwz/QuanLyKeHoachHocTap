namespace WinFormsApp4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt_getdata = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.capchaa = new System.Windows.Forms.PictureBox();
            this.tb_captcha = new System.Windows.Forms.TextBox();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.tb_account = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.capchaa)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_getdata
            // 
            this.bt_getdata.Location = new System.Drawing.Point(223, 114);
            this.bt_getdata.Name = "bt_getdata";
            this.bt_getdata.Size = new System.Drawing.Size(94, 29);
            this.bt_getdata.TabIndex = 0;
            this.bt_getdata.Text = "Lấy dữ liệu";
            this.bt_getdata.UseVisualStyleBackColor = true;
            this.bt_getdata.Click += new System.EventHandler(this.bt_getdata_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(468, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // capchaa
            // 
            this.capchaa.Location = new System.Drawing.Point(61, 166);
            this.capchaa.Name = "capchaa";
            this.capchaa.Size = new System.Drawing.Size(318, 62);
            this.capchaa.TabIndex = 2;
            this.capchaa.TabStop = false;
            // 
            // tb_captcha
            // 
            this.tb_captcha.Location = new System.Drawing.Point(403, 318);
            this.tb_captcha.Name = "tb_captcha";
            this.tb_captcha.Size = new System.Drawing.Size(125, 27);
            this.tb_captcha.TabIndex = 3;
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(403, 254);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(125, 27);
            this.tb_password.TabIndex = 4;
            // 
            // tb_account
            // 
            this.tb_account.Location = new System.Drawing.Point(403, 190);
            this.tb_account.Name = "tb_account";
            this.tb_account.Size = new System.Drawing.Size(125, 27);
            this.tb_account.TabIndex = 5;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(143, 291);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 6;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(342, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(101, 24);
            this.checkBox1.TabIndex = 7;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(294, 384);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 8;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(761, 276);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(94, 29);
            this.button4.TabIndex = 9;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(458, 393);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(125, 27);
            this.textBox1.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 605);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tb_account);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.tb_captcha);
            this.Controls.Add(this.capchaa);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_getdata);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.capchaa)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button bt_getdata;
        private Button button1;
        private PictureBox capchaa;
        private TextBox tb_captcha;
        private TextBox tb_password;
        private TextBox tb_account;
        private Button button2;
        private CheckBox checkBox1;
        private Button button3;
        private Button button4;
        private TextBox textBox1;
    }
}