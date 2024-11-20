using Auth.DEPI.Final.BLL;
using Auth.DEPI.Final.BLL.Interfaces;
using Auth.DEPI.Final.BLL.Repository;
using Auth.DEPI.Final.DAL.Data.Context;
using Auth.DEPI.Final.DAL.Entities;
using Auth.DEPI.Final.PL.Mapping.CoursesMapping;
using Auth.DEPI.Final.PL.Mapping.InstructorMapping;
<<<<<<< Updated upstream
=======
using Auth.DEPI.Final.PL.Mapping.StudentMapping;
using Auth.DEPI.Final.PL.Mapping.VideoMapping;
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Auth.DEPI.Final.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

			// Register RoleManager for IdentityRole

            builder.Services.AddIdentity<User,IdentityRole>()
                            .AddEntityFrameworkStores<ApplicationDbContext>()
                            .AddDefaultTokenProviders();

            builder.Services.ConfigureApplicationCookie(config =>
            {
                config.LoginPath = "/Auth/SignIn";
            });



            builder.Services.AddScoped<ICourseRepository, CoursesRepository>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

            builder.Services.AddAutoMapper(M => M.AddProfile(new CourseProfile()));
<<<<<<< Updated upstream
            builder.Services.AddAutoMapper(M => M.AddProfile(new InstructorProfile()));
=======
           builder.Services.AddAutoMapper(M => M.AddProfile(new InstructorProfile()));
            builder.Services.AddAutoMapper(M => M.AddProfile(new VideoProfile()));
            builder.Services.AddAutoMapper(M => M.AddProfile(new StudentProfile()));
>>>>>>> Stashed changes


            var app = builder.Build();





            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
