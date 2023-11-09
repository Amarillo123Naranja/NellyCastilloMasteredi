using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DL;

public partial class NellyCastilloEmisorContext : DbContext
{
    public NellyCastilloEmisorContext()
    {
    }

    public NellyCastilloEmisorContext(DbContextOptions<NellyCastilloEmisorContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Emisor> Emisors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-15TRT047; Database= NellyCastilloEmisor; TrustServerCertificate=True; User ID=sa; Password=pass@word1;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Emisor>(entity =>
        {
            entity.HasKey(e => e.IdEmisor).HasName("PK__Emisor__1F619ADC1786AD92");

            entity.ToTable("Emisor");

            entity.Property(e => e.IdEmisor)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Capital).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.FechaInicioOperacion).HasColumnType("date");
            entity.Property(e => e.Rfc)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
