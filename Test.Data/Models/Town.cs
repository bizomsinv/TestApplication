using System;
using System.Collections.Generic;

#nullable disable

namespace Test.Data.Models
{
    public partial class Town
    {
        public Town()
        {
            PersonIdtownBornNavigations = new HashSet<Person>();
            PersonIdtownLivesNavigations = new HashSet<Person>();
        }

        public string Idtown { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Person> PersonIdtownBornNavigations { get; set; }
        public virtual ICollection<Person> PersonIdtownLivesNavigations { get; set; }
    }
}
