using System;
using System.Collections.Generic;
using BlazorApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Data;

public partial class KutyamenhelyContext : DbContext
{
    public KutyamenhelyContext()
    {
    }

    public KutyamenhelyContext(DbContextOptions<KutyamenhelyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Kutya> Kutyas { get; set; }

    public virtual DbSet<Kutyafajtum> Kutyafajta { get; set; }

    public virtual DbSet<Kutyatulajdono> Kutyatulajdonos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=localhost;user=Blazor;password=Bl@zor12345;database=kutyamenhely");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Kutya>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kutya");

            entity.HasIndex(e => e.GazdinevId, "gazdinevId");

            entity.HasIndex(e => e.KutyafajtaId, "kutyafajtaId");

            entity.Property(e => e.GazdinevId).HasColumnName("gazdinevId");
            entity.Property(e => e.KutyafajtaId).HasColumnName("kutyafajtaId");
            entity.Property(e => e.Kutyanev)
                .HasMaxLength(25)
                .HasColumnName("kutyanev");

            entity.HasOne(d => d.Gazdinev).WithMany(p => p.Kutyas)
                .HasForeignKey(d => d.GazdinevId)
                .HasConstraintName("kutya_ibfk_1");

            entity.HasOne(d => d.Kutyafajta).WithMany(p => p.Kutyas)
                .HasForeignKey(d => d.KutyafajtaId)
                .HasConstraintName("kutya_ibfk_2");
        });

        modelBuilder.Entity<Kutyafajtum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kutyafajta");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Fajta)
                .HasMaxLength(100)
                .HasColumnName("fajta");
        });

        modelBuilder.Entity<Kutyatulajdono>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("kutyatulajdonos");

            entity.Property(e => e.Gazdinev)
                .HasMaxLength(25)
                .HasColumnName("gazdinev");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
