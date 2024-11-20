using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineLearningPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Auth.DEPI.Final.DAL.Data.Configurations
{
    public class StudentCourseConfigurations : IEntityTypeConfiguration<StudentCourses>
    {
        public void Configure(EntityTypeBuilder<StudentCourses> builder)
        {
            builder.HasKey(sc => new { sc.StudentId, sc.CourseId });


            builder.HasOne(sc => sc.Student)
                   .WithMany(s => s.StudentCourses)
                   .HasForeignKey(sc => sc.StudentId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(sc => sc.Course)
                   .WithMany(c => c.StudentCourses)
                   .HasForeignKey(sc => sc.CourseId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
