using Microsoft.AspNet.Identity.EntityFramework;
using Saglik.Entity.Entity;
using Saglik.Entity.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.DAL.Context
{
    public class SaglikContext : IdentityDbContext<ApplicationUser>
    {
        public SaglikContext() : base("SaglikContext")
        {

        }

        public virtual DbSet<Kategori> Kategoriler { get; set; }
        public virtual DbSet<AltKategori> AltKategoriler { get; set; }
        public virtual DbSet<Urun> Urunler { get; set; }
        public virtual DbSet<Satis> Satislar { get; set; }
        public virtual DbSet<SatisDetay> SatisDetaylar { get; set; }
        public virtual DbSet<Uye> Uyeler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AltKategori>()
                .HasRequired<Kategori>(x => x.Kategori)
                .WithMany(x => x.AltKategoriler)
                .HasForeignKey(x => x.kategoriID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasRequired<Kategori>(x => x.Kategori)
                .WithMany(x => x.Urunler)
                .HasForeignKey(x => x.kategoriID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Urun>()
                .HasRequired<AltKategori>(x => x.AltKategori)
                .WithMany(x => x.Urunler)
                .HasForeignKey(x => x.altkategoriID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisDetay>()
                .HasRequired<Satis>(x => x.Satis)
                .WithMany(x => x.SatisDetaylar)
                .HasForeignKey(x => x.satisID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SatisDetay>()
                 .HasRequired<Urun>(x => x.Urun)
                 .WithMany(x => x.SatisDetaylar)
                 .HasForeignKey(x => x.urunID)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Satis>()
                 .HasRequired<Uye>(x => x.Uye)
                 .WithMany(x => x.Satislar)
                 .HasForeignKey(x => x.uyeID)
                 .WillCascadeOnDelete(false);

            modelBuilder.Entity<Uye>()
                .Property(x => x.adres)
                .IsOptional().HasMaxLength(150);

            modelBuilder.Entity<Uye>()
                .Property(x => x.UserId)
                .IsOptional();

            base.OnModelCreating(modelBuilder);
        }
    }
}
