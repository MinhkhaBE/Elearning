using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Learning.Data
{
    public class Subject
    {
        public int Idsubject { get; set; }
        public string Namesubject { get; set; }

        //relationship

        public ICollection<Class> Classes { get; set; }
        
        public ICollection<Test> Tests { get; set; }

        public ICollection<Scorelearning> Scorelearnings { get; set; }
        public Subject()
        {
            Classes = new List<Class>();
            Tests = new List<Test>();
            Scorelearnings = new List<Scorelearning>();
        }
    }
}
