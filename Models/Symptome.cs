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
        public string Symptoms { get; set; }

        public string Causes { get; set; }

        public string Treatment { get; set; }
    }
}
