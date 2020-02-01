﻿// <auto-generated />
using CubeGPS.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CubeGPS.Repository.Migrations
{
    [DbContext(typeof(GPSContext))]
    [Migration("20200201185619_InitializeDB")]
    partial class InitializeDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CubeGPS.Repository.Models.Circle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10, 8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<decimal>("Radius")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<int>("ShapeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShapeId");

                    b.ToTable("Circle");
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.IrregularShape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(10, 8)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<int>("ShapeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShapeId");

                    b.ToTable("IrregularShape");
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.Rectangle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Latitude1")
                        .HasColumnType("decimal(10, 8)");

                    b.Property<decimal>("Latitude2")
                        .HasColumnType("decimal(10, 8)");

                    b.Property<decimal>("Longitude1")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<decimal>("Longitude2")
                        .HasColumnType("decimal(11, 8)");

                    b.Property<int>("ShapeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShapeId");

                    b.ToTable("Rectangle");
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.Shape", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TypeId");

                    b.ToTable("Shape");
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.ShapeType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.ToTable("ShapeType");
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.Circle", b =>
                {
                    b.HasOne("CubeGPS.Repository.Models.Shape", "Shape")
                        .WithMany("Circle")
                        .HasForeignKey("ShapeId")
                        .HasConstraintName("FK_Circle_Shape")
                        .IsRequired();
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.IrregularShape", b =>
                {
                    b.HasOne("CubeGPS.Repository.Models.Shape", "Shape")
                        .WithMany("IrregularShape")
                        .HasForeignKey("ShapeId")
                        .HasConstraintName("FK_IrregularShape_Shape")
                        .IsRequired();
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.Rectangle", b =>
                {
                    b.HasOne("CubeGPS.Repository.Models.Shape", "Shape")
                        .WithMany("Rectangle")
                        .HasForeignKey("ShapeId")
                        .HasConstraintName("FK_Rectangle_Shape")
                        .IsRequired();
                });

            modelBuilder.Entity("CubeGPS.Repository.Models.Shape", b =>
                {
                    b.HasOne("CubeGPS.Repository.Models.ShapeType", "Type")
                        .WithMany("Shape")
                        .HasForeignKey("TypeId")
                        .HasConstraintName("FK_Shape_ShapeType")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}