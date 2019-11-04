using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Ariel.Paixao.Web.Razor.Dominios
{
    public partial class LanHouseContext : DbContext
    {
        public LanHouseContext()
        {
        }

        public LanHouseContext(DbContextOptions<LanHouseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<RegistroDefeitos> RegistroDefeitos { get; set; }
        public virtual DbSet<TiposDefeitos> TiposDefeitos { get; set; }
        public virtual DbSet<TiposEquipamentos> TiposEquipamentos { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
                optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=Ariel_Paixao_LanHouseSAEP;User Id=sa;Password=132");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RegistroDefeitos>(entity =>
            {
                entity.Property(e => e.DataChamado).HasColumnType("datetime");

                entity.Property(e => e.Descricao).HasColumnType("text");

                entity.HasOne(d => d.IdTipoDefeitoNavigation)
                    .WithMany(p => p.RegistroDefeitos)
                    .HasForeignKey(d => d.IdTipoDefeito)
                    .HasConstraintName("FK__RegistroD__IdTip__534D60F1");

                entity.HasOne(d => d.IdTipoEquipamentoNavigation)
                    .WithMany(p => p.RegistroDefeitos)
                    .HasForeignKey(d => d.IdTipoEquipamento)
                    .HasConstraintName("FK__RegistroD__IdTip__52593CB8");
            });

            modelBuilder.Entity<TiposDefeitos>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TiposDef__7D8FE3B2AC24BA4E")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TiposEquipamentos>(entity =>
            {
                entity.HasIndex(e => e.Nome)
                    .HasName("UQ__TiposEqu__7D8FE3B2FD93B5AB")
                    .IsUnique();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Usuarios__A9D1053460586CB7")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });
        }
    }
}
