using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DinnerParty
{
    public class Person
    {
        public string Name { get; set; }
        public Person LookingAt { get; set; }
        public bool IsMarried { get; set; } //Even though the problem allows for this to be unknown a person is either married or is not
    }   
}
