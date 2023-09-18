﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebCosmetic
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
            services.AddControllersWithViews();

            services.AddSession(
                options =>
                {
                    options.IdleTimeout = TimeSpan.FromDays(30);
                });

            services.AddAuthorization(
                options =>
                {
                    options.AddPolicy("customerTerm", policy =>
                    {
            // đn
            policy.RequireRole("customer");
                        policy.RequireAuthenticatedUser();

                    });
                    options.AddPolicy("staffTerm", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireRole("admin");

                    });
                    options.AddPolicy("adminTerm", policy =>
                    {
                        policy.RequireAuthenticatedUser();
                        policy.RequireRole("staff");
                    });
                }
                );
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseRouting();

            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=IndexHome}/{id?}"
                );
            });

        }
    }
}
