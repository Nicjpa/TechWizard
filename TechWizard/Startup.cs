using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechWizard.Business.Helpers;
using TechWizard.Business.Services;
using TechWizard.Business.Services.IServices;
using TechWizard.Data;
using TechWizard.Data.Models.Entities;
using TechWizard.Data.Repositories.FakeEmailSender;
using TechWizard.Data.Repositories.IRepositories;
using TechWizard.Data.Repositories.Repositories;

namespace TechWizard
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
            services.AddDbContext<WizardDbContext>(options =>  {

                options.UseSqlServer(Configuration.GetConnectionString("SQLConnection"));
                //options.EnableSensitiveDataLogging();
            });

            services.AddIdentity<WizardUser, IdentityRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<WizardDbContext>()
            .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = $"/Identity/Account/Login";
                opt.LogoutPath = $"/Identity/Account/Logout";
                opt.AccessDeniedPath = $"/Identity/Account/AccessDenied";
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IHardwareRepository, HardwareRepository>();
            services.AddScoped<IViewModelService, ViewModelService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IShoppingCartRepository, ShoppingCartRepository>();

            services.AddScoped<IFileService, FileService>();

            services.AddSingleton<IEmailSender, EmailSender>();

            services.AddAutoMapper(typeof(AutoMapperProfile));

            services.AddControllers().AddNewtonsoftJson();

            services.AddControllersWithViews();

            services.AddRazorPages();
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
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
