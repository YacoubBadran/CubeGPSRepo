using System;
using CubeGPS.Repository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CubeGPS.Repository
{
    public partial class GPSContext : DbContext
    {
        public GPSContext()
        {
        }

        public GPSContext(DbContextOptions<GPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Circle> Circle { get; set; }
        public virtual DbSet<IrregularShape> IrregularShape { get; set; }
        public virtual DbSet<Rectangle> Rectangle { get; set; }
        public virtual DbSet<Shape> Shape { get; set; }
        public virtual DbSet<ShapeType> ShapeType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {/*
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=GPS;Integrated Security=True;Trusted_Connection=True;");
            }*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Circle>(entity =>
            {
                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Radius).HasColumnType("decimal(11, 8)");

                entity.HasOne(d => d.Shape)
                    .WithMany(p => p.Circle)
                    .HasForeignKey(d => d.ShapeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Circle_Shape");
            });

            modelBuilder.Entity<IrregularShape>(entity =>
            {
                entity.Property(e => e.Latitude).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude).HasColumnType("decimal(11, 8)");

                entity.HasOne(d => d.Shape)
                    .WithMany(p => p.IrregularShape)
                    .HasForeignKey(d => d.ShapeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_IrregularShape_Shape");
            });

            modelBuilder.Entity<Rectangle>(entity =>
            {
                entity.Property(e => e.Latitude1).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Latitude2).HasColumnType("decimal(10, 8)");

                entity.Property(e => e.Longitude1).HasColumnType("decimal(11, 8)");

                entity.Property(e => e.Longitude2).HasColumnType("decimal(11, 8)");

                entity.HasOne(d => d.Shape)
                    .WithMany(p => p.Rectangle)
                    .HasForeignKey(d => d.ShapeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Rectangle_Shape");
            });

            modelBuilder.Entity<Shape>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.Shape)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Shape_ShapeType");
            });

            modelBuilder.Entity<ShapeType>(entity =>
            {
                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
