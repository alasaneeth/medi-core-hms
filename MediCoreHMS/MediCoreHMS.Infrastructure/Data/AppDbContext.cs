using MediCoreHMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MediCoreHMS.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Role> Roles => Set<Role>();
    public DbSet<Patient> Patients => Set<Patient>();
    public DbSet<Doctor> Doctors => Set<Doctor>();
    public DbSet<Appointment> Appointments => Set<Appointment>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Role>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Patient>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Doctor>().HasQueryFilter(x => !x.IsDeleted);
        modelBuilder.Entity<Appointment>().HasQueryFilter(x => !x.IsDeleted);

        modelBuilder.Entity<Doctor>()
    .Property(d => d.ConsultationFee)
    .HasColumnType("decimal(18,2)");
    }
}