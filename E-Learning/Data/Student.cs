using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{

    public class Student
    {

        public int Idstudent { get; set; }
        public string Namestudent { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime Birth { get; set; }
        public int Idaccount { get; set; }

        //relationship
        public Account Account { get; set; }
        public Scorelearning Scorelearning { get; set; }


    }
}
