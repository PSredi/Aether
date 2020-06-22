using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aether.Infrastructure.Helpers;
using Aether.Application.Data.Repositories;
using Aether.Application.UseCases.User;
using Aether.Application.UseCases.User.Implementation.AuthenticateUserCommand;
using Aether.Application.UseCases.User.Implementation.RegisterUserCommand;
using Aether.Persistence.Data;
using Aether.Persistence.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Aether.Application.Helpers;

namespace Aether.Presentation
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static")]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddApplication();
            services.AddInfrastructure();
            services.AddPersistence(Configuration);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Performance", "CA1822:Mark members as static")]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
