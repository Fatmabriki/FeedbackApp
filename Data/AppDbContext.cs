using Microsoft.EntityFrameworkCore;
using FeedbackApp.Models;

namespace FeedbackApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Wilaya> Wilayas { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Village> Villages { get; set; }
        public DbSet<Experience> Experiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Experience>()
                .HasOne(e => e.Region)
                .WithMany()
                .HasForeignKey(e => e.RegionId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Experience>()
                .HasOne(e => e.Wilaya)
                .WithMany()
                .HasForeignKey(e => e.WilayaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Experience>()
                .HasOne(e => e.Area)
                .WithMany()
                .HasForeignKey(e => e.AreaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Experience>()
                .HasOne(e => e.Village)
                .WithMany()
                .HasForeignKey(e => e.VillageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }

}
