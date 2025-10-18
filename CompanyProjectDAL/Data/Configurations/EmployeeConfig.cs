using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyProjectDAL.Data.Configurations
{
    internal class EmployeeConfig : BaseEntityConfig<Employee>, IEntityTypeConfiguration<Employee>
    {
        public new void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.Property<int>("Id").UseIdentityColumn(1, 1);
            builder.Property(x => x.Name).HasColumnType("varchar(50)");
            builder.Property(x => x.Address).HasColumnType("varchar(150)");
            builder.Property(x => x.Salary).HasColumnType("decimal(10,2)");

            builder.Property(x => x.Gender).HasConversion(emp => emp.ToString(),
                    gnd => (Gender) Enum.Parse(typeof(Gender), gnd));

            builder.Property(x => x.EmployeeType).HasConversion(emp => emp.ToString(),
                    type => (EmployeeType)Enum.Parse(typeof(EmployeeType), type));

            base.Configure(builder);

        }
    }
}
