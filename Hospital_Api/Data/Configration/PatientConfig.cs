using Microsoft.EntityFrameworkCore;
using Hospital_Api.Model;

namespace Hospital_Api.Data.Configration
{
    public class PatientConfig : IEntityTypeConfiguration<Patient>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Patient> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Patients");

            builder.HasMany(x => x.Doctors).WithMany(x => x.Patients);
        }
    }
}
