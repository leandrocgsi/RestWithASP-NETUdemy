using System;
using System.Collections.Generic;

using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;

using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Business.Implementattions;
using RestWithASPNETUdemy.Repository.Generic;
using Hypermedia;
using RestWithASPNETUdemy.HyperMedia;
using Microsoft.Net.Http.Headers;
using Hypermedia.Filters;

namespace RestWithASPNETUdemy
{
    public class Startup
    {
        private readonly ILogger _logger;
        public IConfiguration _configuration { get; }
        public IHostingEnvironment _environment { get; }

        public Startup(IConfiguration configuration, IHostingEnvironment environment, ILogger<Startup> logger)
        {
            _configuration = configuration;
            _environment = environment;
            _logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _configuration["MySqlConnection:MySqlConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connectionString));

            if (_environment.IsDevelopment())
            {
                try
                {
                    var evolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connectionString);

                    var evolve = new Evolve.Evolve("evolve.json", evolveConnection, msg => _logger.LogInformation(msg))
                    {
                        Locations = new List<string> { "db/migrations" },
                        IsEraseDisabled = true,
                    };

                    evolve.Migrate();

                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Database migration failed.", ex);
                    throw;
                }
            }

            services.AddMvc(options =>
            {
                options.RespectBrowserAcceptHeader = true;
                options.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("text/xml"));
                options.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));

            })
            .AddXmlSerializerFormatters();

            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ObjectContentResponseEnricherList.Add(new PersonEnricher());
            filterOptions.ObjectContentResponseEnricherList.Add(new BookEnricher());

            services.AddSingleton(filterOptions);

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            services.AddScoped<IPersonBusiness, PersonBusinessImpl>();
            services.AddScoped<IBookBusiness, BookBusinessImpl>();

            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(_configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "DefaultApi",
                    template:"{controller=Values}/{id?}");
            });
        }
    }
}
