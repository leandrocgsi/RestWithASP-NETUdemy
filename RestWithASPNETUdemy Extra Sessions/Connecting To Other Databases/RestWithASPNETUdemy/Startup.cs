using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Business.Implementattions;
using Microsoft.EntityFrameworkCore;
//using DataAccessMySqlProvider.Context;
//using DataAccessMySqlProvider.Repository.Implementattions;
using DomainModel.Model.Repository;
using DataAccessPostgreeSQLProvider.Context;
using DataAccessPostgreeSQLProvider.Repository.Implementattions;

namespace RestWithASPNETUdemy
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //Using a MySQL database
            /*var connectionString = Configuration["MySqlConnection:MySqlConnectionString"];

            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString)); */

            //Using a PostgreSQL database
            var connectionString = Configuration["PostgreeSqlConnection:PostgreeSqlConnectionString"];

            services.AddDbContext<PostgreeSQLContext>(options => options.UseNpgsql(connectionString));

            services.AddMvc();

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IPersonRepository, PersonRepositoryImpl>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }
    }
}
