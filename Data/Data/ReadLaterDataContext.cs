using Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class ReadLaterDataContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ReadLaterDataContext(DbContextOptions<ReadLaterDataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Bookmark> Bookmarks { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
