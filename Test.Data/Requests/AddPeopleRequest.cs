using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Requests
{
    public class AddPeopleRequest
    {
        public string IdTownBorn { get; set; }
        public string IdTownLives { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
