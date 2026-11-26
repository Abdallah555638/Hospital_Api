using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital_Api.Model;

namespace Hospital_Api.Data.Configration
{
    public class Medical_DeviceConfig : IEntityTypeConfiguration<Medical_Device>
    {
        public void Configure(EntityTypeBuilder<Medical_Device> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Medical_Devices");

            builder.HasOne(x => x.Patient).WithOne(x => x.medical_device).HasForeignKey<Medical_Device>(x => x.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
