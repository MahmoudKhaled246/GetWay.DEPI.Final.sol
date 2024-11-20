using Auth.DEPI.Final.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.DAL.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        public ApplicationDbContext(DbContextOptions options) : base(options) 
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Apply Table Per Concrete Class (TPC) strategy

            builder.Entity<Admin>().ToTable("Admins");
            builder.Entity<Instructor>().ToTable("Instructors");
            builder.Entity<Student>().ToTable("Students");

            var roleAdmin = new IdentityRole { Id = "admin", Name = "Admin", NormalizedName = "ADMIN" };
            var roleInstructor = new IdentityRole { Id = "instructor", Name = "Instructor", NormalizedName = "INSTRUCTOR" };
            var roleStudent = new IdentityRole { Id = "student", Name = "Student", NormalizedName = "STUDENT" };

            builder.Entity<IdentityRole>().HasData(roleAdmin, roleInstructor, roleStudent);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }


        public DbSet<Admin> Admins { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }

    }
}
