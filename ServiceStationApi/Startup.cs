using System;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using ServiceStationApi.Business;
using ServiceStationApi.Infrastructure;
using ServiceStationApi.Infrastructure.Repository;

namespace ServiceStationApi
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
            // get the connection string from the config file
            string connection = Configuration.GetConnectionString("DefaultConnection");
            //  add the MobileContext context as a service to the application
            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(connection));

            services.AddFluentMigratorCore()
                .ConfigureRunner(config =>
                    config.AddSqlServer()
                    .WithGlobalConnectionString(connection)
                    //.ScanIn(Assembly.GetExecutingAssembly()).For.All())
                    .ScanIn(typeof(ApplicationContext).Assembly).For.Migrations())

                    .AddLogging(config => config.AddFluentMigratorConsole());



            services.AddControllers();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>(); 
            services.AddDbContext<ApplicationContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext applicationContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            
            try
            {
                Log.Information("Getting the create BD...");
                applicationContext.Database.Migrate();
            }
            catch (Exception ex) 
            {
                Log.Fatal(ex, "Unable to create database");
                
            }
            finally
            {
                Log.CloseAndFlush();
               
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseMvc(routes=>
            //{
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});


        }

    }
}
