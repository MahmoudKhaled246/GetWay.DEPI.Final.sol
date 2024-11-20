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
    public class VideoConfigurations : IEntityTypeConfiguration<Video>
    {
        public void Configure(EntityTypeBuilder<Video> builder)
        {
            builder.HasOne(v => v.Courses)
                   .WithMany(c => c.Videos)
                   .HasForeignKey(v => v.CourseId);
        }
    }
}
