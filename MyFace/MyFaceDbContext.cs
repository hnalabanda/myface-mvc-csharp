using Microsoft.EntityFrameworkCore;
using MyFace.Models.Database;

namespace MyFace
{
    public class MyFaceDbContext : DbContext
    {
        public MyFaceDbContext(DbContextOptions<MyFaceDbContext> options) : base(options) {}
        
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Interaction> Interactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .HasOne(p => p.User)
                .WithMany(u => u.Posts)
                .HasForeignKey(p => p.UserId)
                .IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(u => u.Interactions)
                .WithOne(i => i.User);
            modelBuilder.Entity<Interaction>()
                .HasOne(i => i.Post)
                .WithMany(p => p.Interactions);
        }
    }
}