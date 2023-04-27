using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(240, 244, 252);
            this.StartPosition = FormStartPosition.CenterScreen;
            textBox2.UseSystemPasswordChar = true;
            textBox4.UseSystemPasswordChar = true;
        }

        public RegisterForm(Form lgform)
        {
            this.form = lgform;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            textBox2.UseSystemPasswordChar = true;
            textBox4.UseSystemPasswordChar = true;
            this.BackColor = Color.FromArgb(240, 244, 252);
        }
        Form form = new Form();
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox4.Text)
            {
                MessageBox.Show("Mật khẩu không khớp", "Lưu ý!");
                return;
            }
            register rg = new register();
            if (rg.RegisterStudent(textBox1.Text, textBox2.Text, textBox3.Text))
            {
                this.Close();
                form.Show();
            }
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }

        private void chkShowpas_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowpas.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
                textBox4.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
                textBox4.UseSystemPasswordChar = true;
            }
        }
    }
}
