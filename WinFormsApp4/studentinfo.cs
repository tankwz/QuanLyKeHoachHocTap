using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class studentinfo
    {
        /*
           st_id NVARCHAR(8) PRIMARY KEY,
  st_password_hash NVARCHAR(64),
  st_name NVARCHAR(50),
  faculty NVARCHAR(50),
  GPA FLOAT
         */
        public string St_id { get => st_id; set => st_id = value; }

        public string St_password_hash { get => st_password_hash; set => st_password_hash = value; }
        public string St_name { get => st_name; set => st_name = value; }
        public string Faculty { get => faculty; set => faculty = value; }
        public double GPA { get => gpa; set => gpa = value; }


        private string st_id;
        private string st_password_hash;
        private string st_name;
        private string faculty;
        private double gpa;


        public studentinfo(string st_id, string st_password_hash, string st_name, string faculty, double gpa)
        {
            St_id = st_id;
            St_password_hash = st_password_hash;
            St_name = st_name;
            Faculty = faculty;
            GPA = gpa;
        }

        public studentinfo() { }
    }
}
