﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{
    public class Test
    {
        public int Idtest { get; set; }
        public string Nametest { get; set; }
        public string Content { get; set; }
        public string Time { get; set; }
        public DateTime Createdate { get; set; }
        public double Score { get; set; }
        public string Status { get; set; }
        public int Idsubject { get; set; }

        //relationship
        public Subject Subject { get; set; }


    }
}
