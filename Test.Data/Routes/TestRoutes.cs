using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Data.Routes
{
    public static class TestRoutes
    {
        public const string GetTown = "town";
        public const string GetTownWithQuery = "town";
        public const string GetPeople = "people/{townId}";
        public const string AddPeople = "people";
    }
}
