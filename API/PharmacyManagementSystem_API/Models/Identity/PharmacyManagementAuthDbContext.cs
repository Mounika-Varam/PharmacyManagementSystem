using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PharmacyManagementSystem.API.Models.Identity
{
    public class PharmacyManagementAuthDbContext : IdentityDbContext
    {
        public PharmacyManagementAuthDbContext(DbContextOptions<PharmacyManagementAuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var adminRoleId = "282169C6-178A-41F4-ADC4-E66DF12A11C5";
            var doctorRoleId = "E6A81365-1557-443E-BA2D-AC6217E53124";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = adminRoleId,
                    ConcurrencyStamp = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                },
                new IdentityRole
                {
                    Id = doctorRoleId,
                    ConcurrencyStamp = doctorRoleId,
                    Name = "Doctor",
                    NormalizedName = "Doctor".ToUpper()
                },
            };

            builder.Entity<IdentityRole>().HasData(roles);
           
        }
    }
}
  