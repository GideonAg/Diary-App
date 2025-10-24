using DiaryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DiaryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<DiaryEntry> DiaryEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DiaryEntry>().HasData(
                new DiaryEntry { Id = 1, Title = "Jesus Saves", Content = "Jesus saves me", CreatedAt = DateTime.Now },
                new DiaryEntry { Id = 2, Title = "Come to Jesus", Content = "Jesus saves me", CreatedAt = DateTime.Now },
                new DiaryEntry { Id = 3, Title = "All who are heavy laden", Content = "Jesus saves me", CreatedAt = DateTime.Now }
            );
        }

    }
}
