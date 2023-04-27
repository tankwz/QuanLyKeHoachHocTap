using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class studentSubjects
    {
        private string st_id;
        public string St_id { get => st_id; set => st_id = value; }

        private int count;
        public int Count { get => count; set => count = value; }

        private int order;
        public int Order { get => order; set => order = value; }

        private string hknamhoc;
        public string Hknamhoc { get => hknamhoc; set => hknamhoc = value; }

        private string mark;
        public string Mark { get => mark; set => mark = value; }
        private string marktext;
        public string Marktext { get => marktext; set => marktext = value; }
        private string name;
        public string Name { get => name; set => name = value; }
        private string id;
        public string Id { get => id; set => id = value; }

        private int credits;
        public int Credits { get => credits; set => credits = value; }
        
        private string get;
        public string Get { get => get; set => get = value; }



        public studentSubjects(string st_id, int order, int count,string hknamhoc, string marktext, string mark, string name, string id, int credits, string get, int recommend, int opentime)
        {

            St_id = st_id;
            Order = order;
            Count = count;
            Hknamhoc= hknamhoc;
            Mark= mark;
            Marktext = marktext;
            Name= name;
            Id= id;
            Credits = credits;
            Get = get;

        }
        public studentSubjects() { }
    }
}
