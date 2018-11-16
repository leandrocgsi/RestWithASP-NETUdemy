using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessMySqlProvider.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
    }
}
