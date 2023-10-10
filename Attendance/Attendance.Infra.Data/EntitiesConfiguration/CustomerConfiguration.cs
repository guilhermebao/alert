using Attendance.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Attendance.Infra.Data.EntitiesConfiguration;

public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
{
    public void Configure(EntityTypeBuilder<Customer> builder) 
    {
        builder.ToTable("Customers");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Name).HasMaxLength(200).IsRequired();
        builder.Property(c => c.PhoneNumber).HasMaxLength(20).IsRequired();
        builder.Property(c => c.Address).HasMaxLength(100).IsRequired();
        builder.Property(c => c.City).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Neighborhood).HasMaxLength(50).IsRequired();
        builder.Property(c => c.Number).HasMaxLength(10).IsRequired();
    }
}
