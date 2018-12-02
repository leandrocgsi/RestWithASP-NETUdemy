using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace DataAccessSqliteProvider.Context
{
    public class SqliteSQLContext : DbContext
    {
        public SqliteSQLContext()
        {

        }

        public SqliteSQLContext(DbContextOptions<SqliteSQLContext> options) : base(options) {}

        public DbSet<Person> Persons { get; set; }
    }
}
