using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiCondominio.Models
{
    public partial class dbcondominiosContext : DbContext
    {
        public dbcondominiosContext()
        {
        }

        public dbcondominiosContext(DbContextOptions<dbcondominiosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Apartamento> Apartamento { get; set; }
        public virtual DbSet<Apartamentopessoa> Apartamentopessoa { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Apartamento>(entity =>
            {
                entity.HasKey(e => e.Idapartamento);

                entity.ToTable("apartamento", "dbcondominios");

                entity.HasIndex(e => e.Idapartamento)
                    .HasName("idapartamento_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idapartamento)
                    .HasColumnName("idapartamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Bloco)
                    .HasColumnName("bloco")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .HasColumnName("numero")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Apartamentopessoa>(entity =>
            {
                entity.HasKey(e => new { e.Idapartamento, e.Idpessoa });

                entity.ToTable("apartamentopessoa", "dbcondominios");

                entity.HasIndex(e => e.Idpessoa)
                    .HasName("idpessoa_idx");

                entity.Property(e => e.Idapartamento)
                    .HasColumnName("idapartamento")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Idpessoa)
                    .HasColumnName("idpessoa")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.IdapartamentoNavigation)
                    .WithMany(p => p.Apartamentopessoa)
                    .HasForeignKey(d => d.Idapartamento)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idapartamento");

                entity.HasOne(d => d.IdpessoaNavigation)
                    .WithMany(p => p.Apartamentopessoa)
                    .HasForeignKey(d => d.Idpessoa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idpessoa");
            });

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.Idpessoa);

                entity.ToTable("pessoa", "dbcondominios");

                entity.Property(e => e.Idpessoa)
                    .HasColumnName("idpessoa")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Cpf)
                    .HasColumnName("cpf")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Datanascimento)
                    .HasColumnName("datanascimento")
                    .HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.Idusuario);

                entity.ToTable("usuario", "dbcondominios");

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Idusuario)
                    .HasColumnName("idusuario")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(300)
                    .IsUnicode(false);
            });
        }
    }
}
