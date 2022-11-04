using API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<D_User_Role>().HasOne(x => x.D_Role).WithMany(y => y.Users_Roles).HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<D_User_Role>().HasOne(x => x.D_User).WithMany(y => y.Users_Roles).HasForeignKey(x => x.UserId);
        }

        public DbSet<D_State> States { get; set; }
        public DbSet<D_City> Cities { get; set; }
        public DbSet<D_BusinessLicense> BusinessLicenses { get; set; }
        public DbSet<D_SICHeader> SICHeaders { get; set; }
        public DbSet<D_SIC> SICs { get; set; }
        public DbSet<D_User> Users { get; set; }
        public DbSet<D_Role> Roles { get; set; }
        public DbSet<D_User_Role> Users_Roles { get; set; }
    }
}