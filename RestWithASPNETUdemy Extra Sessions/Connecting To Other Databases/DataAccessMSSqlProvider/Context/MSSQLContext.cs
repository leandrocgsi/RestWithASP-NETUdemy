using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessMSSqlServerProvider.Context
{
    public class MSSQLContext : DbContext
    {
        public MSSQLContext(DbContextOptions<MSSQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
    }
}
