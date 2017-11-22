using SINEST.Models;
using System.Data.Entity;

namespace SINEST.Context
{

    public class SinestContext : DbContext
    {
        public SinestContext()
            : base("SinestDB")
        {
        }
        

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        public DbSet<Module> Modules { get; set; }
        public DbSet<Program> Programs { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Module>()
            .HasMany<Role>(m => m.Roles)
            .WithMany(r => r.Modules)
            .Map(cs =>
            {
                cs.MapLeftKey("Module_Id");
                cs.MapRightKey("Role_Id");
                cs.ToTable("ModulesRoles");
            });
        }
    }

}