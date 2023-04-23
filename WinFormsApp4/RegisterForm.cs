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
        }

        public RegisterForm(Form lgform)
        {
            this.form = lgform;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
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
            rg.RegisterStudent(textBox1.Text, textBox2.Text, textBox3.Text);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
            form.Show();
        }
    }
}
