using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using MoviesNetCore.Data;

namespace MoviesNetCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var baseDirectory = AppContext.BaseDirectory;
            var connection = string.Format(@"Data Source={0}/Data/movies.sqlite", baseDirectory);
            services.AddDbContext<MovieContext>(options => options.UseSqlite(connection));

            // Add framework services.
            services.AddCors();  
            services.AddMvc();
            services.AddScoped<IMovieRepository, MovieRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            // need this so local dev client can hit docker
            app.UseCors(builder => builder
                                    .WithOrigins("http://localhost:4070")  // todo configure
                                    .WithMethods("GET", "POST", "PUT", "DELETE")
                                    .AllowAnyHeader());

            app.UseMvc();

            app.Run(context =>
            {
                return context.Response.WriteAsync(string.Format("Movies Net Core Started.  Running at {0}", System.AppContext.BaseDirectory));
            });
        }
    }
}
