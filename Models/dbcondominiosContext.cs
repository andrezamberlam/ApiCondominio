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

        public virtual DbSet<Pessoa> Pessoa { get; set; }

//         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//         {
//             if (!optionsBuilder.IsConfigured)
//             {
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                 optionsBuilder.UseMySQL("Server=localhost;Port=3306;Database=dbcondominios;Uid=root;Pwd=andre000;");
//             }
//         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Pessoa>(entity =>
            {
                entity.HasKey(e => e.Idpessoa);

                entity.ToTable("pessoa", "dbcondominios");

                entity.Property(e => e.Idpessoa)
                    .HasColumnName("idpessoa")
                    .HasColumnType("int(11)")
                    .ValueGeneratedNever();

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
        }
    }
}
