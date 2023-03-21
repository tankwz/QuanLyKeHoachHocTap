using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp4
{
    internal class subjects
    {
        public string Id { get => id; set => id = value; }

        public string Name { get => name; set => name = value; }
        public string Credits { get => credits; set => credits = value; }
        public string Prerequisite { get => prerequisite; set => prerequisite = value; }
        public string Mandatory { get => mandatory; set => mandatory = value; }
        public string Groupz { get => groupz; set => groupz = value; }


        private string id;
        private string name;
        private string credits;
        private string prerequisite;
        private string mandatory;
        private string groupz;



        public subjects(string id, string name,string credits, string prerequisite, string mandatory, string groupz )
        {
            Id = id;
            Name = name;
            Credits = credits;
            Prerequisite = prerequisite;
            Mandatory = mandatory;
            Groupz = groupz;
        }

        public subjects() { }
    }
}
