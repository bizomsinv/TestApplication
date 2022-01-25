using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Data.Models
{
    public partial class Person
    {
        public int Iduser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string IdtownBorn { get; set; }
        public string IdtownLives { get; set; }

        public virtual Town IdtownBornNavigation { get; set; }
        public virtual Town IdtownLivesNavigation { get; set; }
    }
}
