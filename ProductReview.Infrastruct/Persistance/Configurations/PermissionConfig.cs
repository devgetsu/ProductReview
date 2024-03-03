using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductReview.Domain.Entities.Models;

namespace ProductReview.Infrastruct.Persistance.Configurations
{
    public class PermissionConfig : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(new Permission()
            {
                Id = 1,
                Name = "GetAll"
            });

            builder.HasData(new Permission()
            {
                Id = 2,
                Name = "UpdateUser"
            });
            builder.HasData(new Permission()
            {
                Id = 3,
                Name = "DeleteUser"
            });
            builder.HasData(new Permission()
            {
                Id = 4,
                Name = "CreateUser"
            });
        }
    }
}
