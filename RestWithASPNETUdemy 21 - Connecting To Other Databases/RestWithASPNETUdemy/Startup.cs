using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Business.Implementattions;
using Microsoft.EntityFrameworkCore;

using DomainModel.Model.Repository;

//Connect to Sqlite
//using DataAccessSqliteProvider.Context;
//using DataAccessSqliteProvider.Repository.Implementattions;

//Connect to MySQL
using DataAccessMySqlProvider.Context;
using DataAccessMySqlProvider.Repository.Implementattions;

//Connect to Microsoft SQL Server
//using DataAccessMSSqlServerProvider.Context;
//using DataAccessMSSqlServerProvider.Repository.Implementattions;

//Connect to Postgree
//using DataAccessPostgreeSQLProvider.Context;
//using DataAccessPostgreeSQLProvider.Repository.Implementattions;

namespace RestWithASPNETUdemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //Using a SQLite database
            /*var connectionString = Configuration["SqliteSqlConnection:SqliteSqlConnectionString"];
            services.AddDbContext<SqliteSQLContext>(options => options.UseSqlite(connectionString));*/

            //Using a MySQL database
            var connectionString = Configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            //Using a PostgreSQL database
            /*var connectionString = Configuration["PostgreeSqlConnection:PostgreeSqlConnectionString"];
            services.AddDbContext<PostgreeSQLContext>(options => options.UseNpgsql(connectionString));*/

            //Using a Microsoft SQL Server
            /*var connectionString = Configuration["MSSqlServerConnection:MSSqlServerConnectionString"];
            services.AddDbContext<MSSQLServerContext>(options => options.UseSqlServer(connectionString)); */

            services.AddMvc();

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
