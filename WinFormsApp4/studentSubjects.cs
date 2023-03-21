using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class studentSubjects
    {
        private string id;
        private string hknamhoc;
        public string Hknamhoc { get => hknamhoc; set => hknamhoc = value; }

        private string mark;
        public string Mark { get => mark; set => mark = value; }
        private string name;
        public string Name { get => name; set => name = value; }
        public string Id { get => id; set => id = value; }

        public studentSubjects(string hknamhoc, string mark, string name, string id)
        {
            Hknamhoc= hknamhoc;
            Mark= mark;
            Name= name;
            Id= id;
        }
        public studentSubjects() { }
    }
}
