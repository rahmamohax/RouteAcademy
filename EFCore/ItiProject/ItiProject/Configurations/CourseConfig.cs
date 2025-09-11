using ItiProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItiProject.Configurations
{
    internal class CourseConfig : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> c)
        {
            c.Property(c => c.Duration).HasDefaultValue(new TimeSpan(2, 0, 0));
            c.Property(c => c.Name).HasMaxLength(50).IsRequired();
            c.Property(c => c.Description).HasMaxLength(200);
        }
    }
}
