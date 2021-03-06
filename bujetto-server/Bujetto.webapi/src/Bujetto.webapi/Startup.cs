﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace Bujetto.webapi
{
    public class Startup
    {
        private string _cn;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            string dbuser = Environment.GetEnvironmentVariable("DBUSER");
            string dbpwd = Environment.GetEnvironmentVariable("DBPWD");
            string dbhost = Environment.GetEnvironmentVariable("DBHOST");
            string dbport = Environment.GetEnvironmentVariable("DBPORT");
            string db = Environment.GetEnvironmentVariable("DB");

            _cn = $"User ID={dbuser};Password={dbpwd};Host={dbhost};Port={dbport};Database={db};";
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            //cors
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            corsBuilder.AllowCredentials();
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", corsBuilder.Build());
            });


            // Add framework services.
            services.AddMvc();
            services.AddDbContext<BujettoDB.BujettoDbContext>(x => x.UseNpgsql(_cn));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseCors("AllowAll");
            app.UseMvc();
            
        }
    }
}
