using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{
    public class Class
    {
        public int Idclass { get; set; }
        public string Nameclass { get; set; }
        public string Topic { get; set; }
        public string Semester { get; set; }
        public string Status { get; set; }
        public int Idsubject { get; set; }

        //relationship
        public ICollection<Student> Students { get; set; }
        public Class()
        {
            Students = new List<Student>();
        }
        public Classdetail Classdetail { get; set; }
        public Subject Subject { get; set; }




    }
}
