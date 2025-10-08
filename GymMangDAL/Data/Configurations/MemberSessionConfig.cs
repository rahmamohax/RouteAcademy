using GymMangDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymMangDAL.Data.Configurations
{
    internal class MemberSessionConfig : IEntityTypeConfiguration<MemberSession>
    {
        public void Configure(EntityTypeBuilder<MemberSession> b)
        {
            b.Property(x => x.CreatedAt).HasColumnName("BookingDate").HasDefaultValueSql("GETDATE()");
            //b.Property(x => x.IsAttended).HasDefaultValueSql("False");

            b.Ignore(x => x.Id);
            b.HasKey(x => new {x.MemberId, x.SessionId});
        }
    }
}
