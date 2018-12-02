using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessMSSqlServerProvider.Context
{
    public class MSSQLServerContext : DbContext
    {
        public MSSQLServerContext(DbContextOptions<MSSQLServerContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
    }
}
