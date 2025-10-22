
namespace CompanyProjectDAL.Data.Configurations
{
    internal class DepartmentConfig :BaseEntityConfig<Department>, IEntityTypeConfiguration<Department>
    {
        public new void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property<int>("Id").UseIdentityColumn(10,10);
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
            builder.Property(x => x.Code).HasColumnType("varchar(20)");
            builder.Property(x => x.Description).HasColumnType("varchar(150)");

            base.Configure(builder);
        }
    }
}
