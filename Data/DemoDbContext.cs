using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Models;

namespace RdsPostgreSqlAwsIamAuthenticationDotNet6Demo.Data
{
    public class DemoDbContext : IdentityDbContext<User>
    {
        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        
        }
        public DbSet<ToDo> ToDo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);

          //  modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "Admin".ToUpper() });
            this.SeedRoles(modelBuilder);
            this.SeedUsers(modelBuilder);
            this.SeedUserRoles(modelBuilder);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            User user = new User()
            {
                Id = "b74ddd14-6340-4840-95c2-db12554843e5",
                UserName = "Admin01@demo.com",
                Email = "Admin01@demo.com",
                NormalizedUserName = "ADMIN01@DEMO.COM",
                NormalizedEmail= "ADMIN01@DEMO.COM",
                LockoutEnabled = false,
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEDdhw+0rV237aEt6oCNH5WhrTaL1QmRgEfvsLtMnAOI7+JKe1JOQauGlNmxUyK1coQ==",
                SecurityStamp = "5QVX2XDKPW2AIZ7WFYMCY7SXQ2WJAKGX",
                ConcurrencyStamp = "f433e931-54a0-4576-a5a3-7d20da875c59",
                PhoneNumber = "1234567890"
            };

            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
          //  passwordHasher.HashPassword(user, "Admin@01");

            builder.Entity<User>().HasData(user);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Id = "fab4fac1-c546-41de-aebc-a14da6895711", Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "Admin" },
                new IdentityRole() { Id = "c7b013f0-5201-4317-abd8-c211f91b7330", Name = "HR", ConcurrencyStamp = "2", NormalizedName = "Human Resource" }
                );
        }

        private void SeedUserRoles(ModelBuilder builder)
        {
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>() { RoleId = "fab4fac1-c546-41de-aebc-a14da6895711", UserId = "b74ddd14-6340-4840-95c2-db12554843e5" }
                );
        }
    }


}