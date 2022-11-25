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
            modelBuilder.Entity<D_User_Role>().HasOne(x => x.role).WithMany(y => y.users_roles).HasForeignKey(x => x.role_id);
            modelBuilder.Entity<D_User_Role>().HasOne(x => x.user).WithMany(y => y.users_roles).HasForeignKey(x => x.user_id);
        }

        public DbSet<D_User> Users { get; set; }
        public DbSet<D_Role> Roles { get; set; }
        public DbSet<D_User_Role> Users_Roles { get; set; }
        public DbSet<D_StateUS> StatesUS { get; set; }
        public DbSet<D_City> Cities { get; set; }
        public DbSet<D_ZipCode> ZipCodes { get; set; }
        public DbSet<D_BusinessLicense> BusinessLicenses { get; set; }
        public DbSet<D_GroupOfSICCodes> GroupsOfSICCodes { get; set; }
        public DbSet<D_SICCode> SICCodes { get; set; }
        
    }
}