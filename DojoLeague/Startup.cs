using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
// using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using DojoLeague;
using DojoLeague.Factories;

namespace DojoLeague
{
    public class Startup
    {
		public IConfiguration Configuration {get;}
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();
            services.AddSession();
            services.Configure<MySqlOptions>(Configuration.GetSection("DBInfo"));
            services.AddScoped<NinjaFactory>();
            services.AddScoped<DojoFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
			if(env.IsDevelopment())
			{
            	app.UseDeveloperExceptionPage();
			}
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}
