
namespace CompanyProjectDAL.Data.Configurations
{
    internal class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property<int>("Id").UseIdentityColumn(10,10);
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
            builder.Property(x => x.Name).HasColumnType("varchar(20)");
            builder.Property(x => x.Description).HasColumnType("varchar(150)");

            builder.Property(x => x.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(x => x.LastModifiedOn).HasComputedColumnSql("GETDATE()");
        }
    }
}
