using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DL
{
    public partial class ESantiagoBibliotecaBabelContext : DbContext
    {
        public ESantiagoBibliotecaBabelContext()
        {
        }

        public ESantiagoBibliotecaBabelContext(DbContextOptions<ESantiagoBibliotecaBabelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Libro> Libros { get; set; } = null!;
        public virtual DbSet<Ubicacion> Ubicacions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.; Database= ESantiagoBibliotecaBabel; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PK__Libro__3E0B49AD7A4B0503");

                entity.ToTable("Libro");

                entity.Property(e => e.Titulo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Volumen)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUbicacionNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdUbicacion)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Libro__IdUbicaci__1273C1CD");
            });

            modelBuilder.Entity<Ubicacion>(entity =>
            {
                entity.HasKey(e => e.IdUbicacion)
                    .HasName("PK__Ubicacio__778CAB1D2FC8B3AE");

                entity.ToTable("Ubicacion");

                entity.Property(e => e.Estante)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Librero)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Posicion)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sala)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
