using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{
    public class Classdetail
    {
        public int Idclassdetail { get; set; }
        public string Passwordclass { get; set; }
        public string Teacher { get; set; }
        public string Lesson { get; set; }
        public string Studytime { get; set; }
        public string Schedule { get; set; }
        public string description { get; set; }
        public int Idclass { get; set; }


        //relationship
        public Class Class { get; set; }
    }
}
