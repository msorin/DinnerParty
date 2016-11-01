using System.Collections.Generic;
using System.Linq;

namespace DinnerParty
{
    public class Party
    {
        public List<Person> People { get; set; }

        public bool IsMarriedLookingAtUnmarried()
        {
            return People.Any(x => x.IsMarried && 
                    x.LookingAt != null && 
                    !x.LookingAt.IsMarried);
        }
    }
}
