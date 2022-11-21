using Microsoft.EntityFrameworkCore;
using ArtWebsite.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ArtWebsite.Domain
{
    public class ArtWebsiteDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Painting> Paintings { get; set; } = null!;
        public DbSet<PageTextField> PagesTextFields { get; set; } = null!;
        
        public ArtWebsiteDbContext(DbContextOptions<ArtWebsiteDbContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = "c64a24a3-28cb-45c1-bf4d-05c0e264a6b9",
                Name = "admin",
                NormalizedName = "ADMIN"
            });

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = "5ec18f10-1b87-4fa9-bbb5-98167123c2f3",
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, "a1r9t77ts4admin"),
                SecurityStamp = String.Empty
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = "c64a24a3-28cb-45c1-bf4d-05c0e264a6b9",
                UserId = "5ec18f10-1b87-4fa9-bbb5-98167123c2f3"
            });

            modelBuilder.ApplyConfiguration(new PageTextFieldConfig());
        }
    }
}
