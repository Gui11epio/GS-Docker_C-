using GeoAlertaC.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GeoAlertaC.Infrastructure.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Alertas> Alertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("TB_USUARIO");
            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.ToTable("TB_ENDERECO");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).HasColumnName("Id");
                entity.Property(e => e.Bairro).HasColumnName("Bairro");
                entity.Property(e => e.Cidade).HasColumnName("Cidade");
                entity.Property(e => e.UsuarioId).HasColumnName("UsuarioId");
            });

            modelBuilder.Entity<Alertas>(entity =>
            {
                entity.ToTable("TB_ALERTAS");

                entity.HasKey(a => a.Id);

                entity.Property(a => a.Id).HasColumnName("Id");
                entity.Property(a => a.NivelRisco).HasColumnName("NivelRisco");
                entity.Property(a => a.Descricao).HasColumnName("Descricao");
                entity.Property(a => a.Probabilidade).HasColumnName("Probabilidade");
                entity.Property(a => a.DataHora).HasColumnName("DataHora");
                entity.Property(a => a.UsuarioId).HasColumnName("UsuarioId");
                entity.Property(a => a.EnderecoId).HasColumnName("EnderecoId");
            });


            //1:1 Usuario - Endereco
            modelBuilder.Entity<Usuario>()
                .HasOne(u => u.Endereco)
                .WithOne(e => e.Usuario)
                .HasForeignKey<Endereco>(e => e.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            //N:1 Alertas - Usuario
            modelBuilder.Entity<Alertas>()
                .HasOne(a => a.Usuario)
                .WithMany(u => u.Alertas)
                .HasForeignKey(a => a.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            //N:1 Alertas - Endereco
            modelBuilder.Entity<Alertas>()
                .HasOne(a => a.Endereco)
                .WithMany()
                .HasForeignKey(a => a.EnderecoId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
