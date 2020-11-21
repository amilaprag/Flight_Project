using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Flight_Project.Models.Amadeus.Configuration;
using Flight_Project.Repository.Authorization.Amadeus;
using Flight_Project.Repository.Search.Amadeus;
using Flight_Project.SupplierConnecter.Amadeus;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Hangfire;
using Hangfire.MemoryStorage;
using Flight_Project.TaskSheduler;
using Flight_Project.Data;

namespace Flight_Project
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
            services.AddControllers();

            //DB
            services.AddDbContext<DatabaseContext>();

            //Hangfire
            services.AddHangfire(config => config.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseDefaultTypeSerializer()
            .UseMemoryStorage());

            services.AddHangfireServer();

            //Depedency Injection
            services.Add(new ServiceDescriptor(typeof(IAmadeus_SearchRepository), typeof(Amadeus_SearchRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IAmadeusConnecter), typeof(AmadeusConnecter), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IAmadeus_AuthorizationRepository), typeof(Amadeus_AuthorizationRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IDatabaseSheduller), typeof(DatabaseSheduller), ServiceLifetime.Transient));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IBackgroundJobClient bckjobclient,IRecurringJobManager rcringjobManager,IServiceProvider srvcprovider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseHangfireDashboard();
            bckjobclient.Enqueue(() =>Console.WriteLine("First job Hangfire"));
            rcringjobManager.AddOrUpdate(
                "",
                () => srvcprovider.GetService<IDatabaseSheduller>().DbFetchSheduller(),
                // "* * * * *"
                Cron.Daily()
                ); 
        }
    }
}
