using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Hospital_Api.Model;

namespace Hospital_Api.Data.Configration
{
    public class DepartmentConfig : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.ToTable("Departments");

            builder.HasMany(x => x.Doctors).WithOne(x => x.Department).HasForeignKey(x => x.DepartmentId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
