using FlotteApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace FlotteApplication.Data
{
    public class DataSource : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS02;DataBase=Flotte;Trusted_Connection = false;TrustServerCertificate=True;User ID=sa ;Password=rema");

            }
        }
        public virtual DbSet<Engin> Engin {  get; set; }
        public virtual DbSet<Proprietaire> Proprietaire { get; set; }
        public virtual DbSet<Facture> Facture {  get; set; }
        public virtual DbSet<Quotation> Quotation {  get; set; }
        public virtual DbSet<Admin> Admin { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Engin>(entity =>
            {
                entity.Property(e => e.enginId).HasColumnName("enginId");
                entity.HasIndex(e => e.immatriculation).IsUnique();

                entity.Property(e => e.marque)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode();

                entity.Property(e => e.couleur)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode();

                entity.Property(e => e.categorie)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode();

                entity.HasMany(d => d.factures)
                      .WithOne(e => e.Engin)
                      .HasForeignKey(f => f.enginId);


                modelBuilder.Entity<Proprietaire>(entity =>
                {
                    entity.Property(e => e.proprietaireId)
                        .HasColumnName("proId");
                    entity.Property(e => e.name)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                    entity.Property(e => e.type)
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode();
                    entity.HasMany(d => d.ListEngins)
                          .WithOne(e => e.Proprietaire);

                });
                modelBuilder.Entity<Facture>(entity =>
                {
                    entity.Property(e => e.factureId).HasColumnName("facId");

                    entity.Property(e => e.dateFacture)
                        .HasDefaultValueSql("GETDATE()");
                    entity.Property(e => e.montatTotal)
                        .IsRequired();
                    entity.Property(e => e.enginId).HasColumnName("engId");

                    entity.HasOne(d => d.Engin)
                            .WithMany(e => e.factures)
                            .HasForeignKey(d => d.enginId)
                            .OnDelete(DeleteBehavior.NoAction);
                    entity.HasOne(d => d.Quotation)
                          .WithOne(e => e.Facture)
                          .HasForeignKey<Facture>(f => f.quotationId)
                          .OnDelete(DeleteBehavior.NoAction);



                });
                modelBuilder.Entity<Quotation>(entity =>
                {
                    entity.Property(e => e.quotationId).HasColumnName("quoId");
                    entity.Property(e => e.valeurDuVehicule).IsRequired();
                    entity.Property(e => e.tarifDeBase).IsRequired();
                    entity.Property(e => e.majoration);
                    entity.HasOne(e => e.Facture)
                          .WithOne(d => d.Quotation)
                          .HasForeignKey<Quotation>(d => d.quotationId)
                          .OnDelete(DeleteBehavior.NoAction);


                });
                modelBuilder.Entity<Admin>(entity =>
                    {
                        entity.Property(e => e.adminId).HasColumnName("adminId");
                        entity.HasIndex(e => e.name).IsUnique();
                        entity.HasIndex(e => e.password).IsUnique();

                    });
            });
        }  
    }
}
