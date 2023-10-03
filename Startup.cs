﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using WebCosmetic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;

namespace WebCosmetic
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // dotnet aspnet-codegenerator Identity -dc WebCosmetic.Scaffold.QL_COSMETICContext
            services.AddRazorPages();
            this.Configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            services.AddDbContext<WebCosmetic.Scaffold.QL_COSMETICContext>(
                options =>
                {
                    var constring = this.Configuration.GetConnectionString("cosmeticString");
                    options.UseSqlServer(constring);
                }   
                );
            
            services.AddIdentity<CosmeticModel, IdentityRole>()
                .AddEntityFrameworkStores<WebCosmetic.Scaffold.QL_COSMETICContext>().AddDefaultTokenProviders();
            services.AddControllersWithViews();
            // dịch vụ đăng nhập ngoài
            services.AddAuthentication().AddGoogle(
                options =>
                {
                    var getGoogle = this.Configuration.GetSection("Authentications:Google");
                    options.ClientId = getGoogle["ClientId"];
                    options.ClientSecret = getGoogle["ClientSecret"];
                    options.CallbackPath = "/dang-nhap-bang-google";
                }
                );
            // mail
            services.Configure<MailSettings>(this.Configuration.GetSection("MailSettings"));
            services.AddSingleton<IEmailSender, IdentityGmail>();
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
            // identity
            services.ConfigureApplicationCookie(
                options=>
                {
                    options.LoginPath = "/login";
                });
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


            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoint =>
            {
                endpoint.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=IndexHome}/{id?}"
                );
                // cấu hình xong dịch vụ, muốn dùng được thì phải có MapRazorPages
                endpoint.MapRazorPages();
            });
        }
    }
}
