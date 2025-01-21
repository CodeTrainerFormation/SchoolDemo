using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public record School
    {
        public int SchoolID { get; init; }
        public required string Name { get; set; }

        public ICollection<Person> People { get; set; } = new HashSet<Person>();
    }
}
