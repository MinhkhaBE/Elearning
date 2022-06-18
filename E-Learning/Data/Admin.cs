using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{

    public class Admin
    {
        public int Idadmin { get; set; }
        public string Nameadmin { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public int Idaccount { get; set; }


        //relationship
        public Account Account { get; set; }

    }

}
