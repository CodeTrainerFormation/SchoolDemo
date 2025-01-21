using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Dal
{
    public class SchoolContext : DbContext
    {
        public DbSet<Person> People { get; set; } = null!;
        public DbSet<School> Schools { get; set; } = null!;
    }
}
