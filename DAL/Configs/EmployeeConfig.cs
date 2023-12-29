
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configs
{
    internal sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.ToTable("Employees");
            builder.Property(x => x.Employee_ID).HasColumnType("int");
            builder.Property(x => x.Login).HasColumnType("varchar(20)");
            builder.Property(x => x.Password).HasColumnType("varchar(20)");
            builder.HasKey(x => x.Employee_ID);
            builder.HasIndex(x => x.Login).IsUnique();

        }
    }
}
