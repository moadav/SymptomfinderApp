using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Symptomfinder.Models
{
    public class Symptome
    {
 
        public int Id { get; set; }

        public string Name { get; set; }
        public string SymptomInformation { get; set; }
    }

    public class Filter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Selected { get; set; }
    }


}
