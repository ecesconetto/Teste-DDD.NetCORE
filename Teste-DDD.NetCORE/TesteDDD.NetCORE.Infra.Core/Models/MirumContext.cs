using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using TesteDDD.NetCORE.CrossCutting;

namespace TesteDDD.NetCORE.Infra.Core.Models
{
    public partial class MirumContext : DbContext
    {
        public MirumContext()
        {
        }

        public MirumContext(DbContextOptions<MirumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cargo> Cargo { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionStrings.TesteDDDConnection);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SalarioBase).HasColumnType("decimal(10, 2)");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rg)
                    .HasColumnName("RG")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cargo)
                    .WithMany(p => p.Pessoa)
                    .HasForeignKey(d => d.CargoId)
                    .HasConstraintName("FK_Cargo");
            });
        }
    }
}
