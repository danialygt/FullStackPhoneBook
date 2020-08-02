using FullStackPhoneBook.Core.Contracts.People;
using FullStackPhoneBook.Core.Contracts.Phones;
using FullStackPhoneBook.Core.Contracts.Tags;
using FullStackPhoneBook.EndPoints.MVC.Models.AAA;
using FullStackPhoneBook.Infrastructures.DataAccess.Common;
using FullStackPhoneBook.Infrastructures.DataAccess.People;
using FullStackPhoneBook.Infrastructures.DataAccess.Phones;
using FullStackPhoneBook.Infrastructures.DataAccess.Tags;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FullStackPhoneBook.EndPOints.MVC
{
    public class Startup
    {
        public IConfiguration Configuration { get; }



        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection services)
        {
            int minPasswordLenth = int.Parse(Configuration["MinPasswordLenth"]);


            services.AddMvc();
            services.AddDbContext<PhoneBookContext>(c => c.UseSqlServer(Configuration.GetConnectionString("phoneBook")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPersonTagRepository, PersonTagRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();
            services.AddScoped<ITagRepository, TagRepository>();



            services.AddDbContext<UserDbContext>(c => c.UseSqlServer(Configuration.GetConnectionString("aaa")));
            //services.AddScoped<IPasswordValidator<AppUser>, MyPasswordValidatorWithParent>();
            //services.AddScoped<IUserValidator<AppUser>, MyUserValidator>();
            services.AddIdentity<AppUser, MyIdentityRole>(c =>
            {
                c.User.RequireUniqueEmail = true;
                c.Password.RequireDigit = false;
                c.Password.RequiredLength = minPasswordLenth;
                c.Password.RequireLowercase = false;
                c.Password.RequireUppercase = false;
                c.Password.RequireNonAlphanumeric = false;
            }).AddEntityFrameworkStores<UserDbContext>();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();
            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=people}/{action=Index}/{id?}");
            });
            
        }
    }
}
