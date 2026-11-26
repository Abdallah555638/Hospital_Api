using Microsoft.EntityFrameworkCore;
using Hospital_Api.Model;

namespace Hospital_Api.Data
{
    public class App_DbContext : DbContext
    {
        public App_DbContext(DbContextOptions<App_DbContext> options) : base(options)
        {

        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Medical_Device> Medical_Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(App_DbContext).Assembly);   
        }
    }
}
