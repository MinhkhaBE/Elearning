﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{
    public class Teacher
    {
        public int Idteacher { get; set; }
        public string Nameteacher { get; set; }
        public string Gmail { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public DateTime Birth { get; set; }
        public int Idaccount { get; set; }

        //relationship
        public Account Account { get; set; }
    }
}
