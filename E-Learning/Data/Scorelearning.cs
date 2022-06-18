﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{
    public class Scorelearning
    {
        public int Idscore { get; set; }
        public double Scorediligence { get; set; }
        public double Scoreoral { get; set; }
        public double Score15min { get; set; }
        public double Scorecorfficient2 { get; set; }
        public double Scorecorfficient3 { get; set; }
        public double Mediumscore { get; set; }
        public double Totalscore { get; set; }
        public string Result { get; set; }
        public DateTime Updatedate { get; set; }
        public int Idstudent { get; set; }
        public int Idsubject { get; set; }

        //relationship
        public Student Student { get; set; }

        public Subject Subject { get; set; }
    }
}
