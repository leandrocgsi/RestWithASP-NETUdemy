using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessPostgreeSQLProvider.Context
{
    public class PostgreeSQLContext : DbContext
    {
        public PostgreeSQLContext()
        {

        }

        public PostgreeSQLContext(DbContextOptions<PostgreeSQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
    }
}
