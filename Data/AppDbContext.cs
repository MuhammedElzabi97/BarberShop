using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebProjesi.Models;

namespace WebProjesi.Data
{
    public class AppDbContext : IdentityDbContext<Kullanici>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }


        public DbSet<Calisan> Calisanlar { get; set; }
        public DbSet<Hizmet> Hizmetler { get; set; }
        public DbSet<Randevu> Randevular{ get; set; }
        public DbSet<CalisanHizmet> CalisanHizmetler { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // CalisanHizmet varlığını kullanarak Çoktan Çoğa ilişkiyi yapılandırın
             
            modelBuilder.Entity<CalisanHizmet>()
                .HasKey(ch => new { ch.CalisanID, ch.HizmetID }); // Composite Key

            modelBuilder.Entity<CalisanHizmet>()
                .HasOne(ch => ch.Calisan)
                .WithMany(c => c.CalisanHizmetler)
                .HasForeignKey(ch => ch.CalisanID);

            modelBuilder.Entity<CalisanHizmet>()
                .HasOne(ch => ch.Hizmet)
                .WithMany(h => h.CalisanHizmetler)
                .HasForeignKey(ch => ch.HizmetID);

           
        }


    }
}
