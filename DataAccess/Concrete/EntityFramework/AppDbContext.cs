using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class AppDbContext : IdentityDbContext<User, Role, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var relationship in builder.Model.GetEntityTypes()
                           .Where(e => !e.IsOwned())
                           .SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.NoAction;
            }
            base.OnModelCreating(builder);
        }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentUser> AppointmentUsers { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorTitle> DoctorTitles { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
    }
}
