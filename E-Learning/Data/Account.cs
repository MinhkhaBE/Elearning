using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{

    public class Account
    {

        public int Idaccount { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public DateTime Createdate { get; set; }

        //relationship
        public Admin Admin { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }



    }
}
