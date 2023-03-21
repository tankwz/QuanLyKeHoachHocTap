using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class laytenhp : Form
    {
        private class subjects
        {
            public string id { get; set; }
            public string name { get; set; }
            public string credit { get; set; }

        }
        public laytenhp()
        {
            InitializeComponent();


            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            subjects[] subj = new subjects[100];

            for (int asd = 0; asd < 100; ++asd)
            {
                subj[asd] = new subjects();
            }
            string a = richTextBox1.Text;
            a = a.Replace("\t", "").Replace("\r", "");
            int b = 0,i=1;
      //      "QP003Giáo dục quốc phòng – An ninh 1 (*)3\nQP004Giáo dục quốc phòng – An ninh 2 (*)2\nQP005Giáo dục quốc phòng – An ninh 3 (*)3"
            while (a.Contains("CT"))
            {
                b = a.IndexOf("\n");
                //  MessageBox.Show(b.ToString());
                if (b - 1 < 0) b= a.Length;
                subj[i].credit = a.Substring(b-1, 1);

                subj[i].id = a.Substring(0,5);
                subj[i].name = a.Substring(5,b-6).Trim();
                if (b + 1 > a.Length) break;
                a = a.Remove(0,b+1);
                i++;
           }

            for (int c = 1; c<100; c++)
            {
                richTextBox2.Text= richTextBox2.Text+ "execute addsub  '" + subj[c].id + "', N'" + subj[c].name +"', '"+ subj[c].credit + "', '';\n" ;
            //    richTextBox2.Text = richTextBox2.Text + "execute addktpm44 '" + subj[c].id + "', '" + "all" + "', '" + "';\n";
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

    }
}
