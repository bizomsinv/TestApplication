using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Responses
{
    public class GetPeopleFromTownQueryResponse
    {
        public string Idtown { get; set; }
        public string PeopleName { get; set; }
        public string PeopleSurname { get; set; }
        public string Born { get; set; }
        public string Lives { get; set; }
    }
}
