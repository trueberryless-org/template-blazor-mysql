using Model.Entities;
using Model.Entities.Authentication;
using Model.Entities.Log;

namespace Model.Configuration;

public class ModelDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<RoleClaim> RoleClaims { get; set; }
    public DbSet<LogEntry> LogEntries { get; set; }
    
    public ModelDbContext(DbContextOptions<ModelDbContext> options) : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // FOREIGN KEYS
        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.Role)
            .WithMany(r => r.RoleClaims)
            .HasForeignKey(rc => rc.RoleId);

        modelBuilder.Entity<RoleClaim>()
            .HasOne(rc => rc.User)
            .WithMany(u => u.RoleClaims)
            .HasForeignKey(rc => rc.UserId);
        
        modelBuilder.Entity<LogEntry>()
            .HasOne(le => le.User)
            .WithMany()
            .HasForeignKey(le => le.UserId);
        
        // UNIQUE
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<Role>()
            .HasIndex(r => r.Identifier)
            .IsUnique();
        
        // HAS KEY
        modelBuilder.Entity<RoleClaim>()
            .HasKey(rc => new { rc.UserId, rc.RoleId });
        
        // ENUMS
        modelBuilder.Entity<LogEntry>()
            .Property(le => le.FieldType)
            .HasConversion<string>();
        
        // SEEDING
        modelBuilder.Entity<Role>()
            .HasData(new Role { Id = 1, Identifier = "Admin", Description = "Administrator" });
    }
}