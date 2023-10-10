using Attendance.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Attendance.Infra.Data.Context;

public class AppDbContext : DbContext
{
    protected AppDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Appointment> Appointments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}
