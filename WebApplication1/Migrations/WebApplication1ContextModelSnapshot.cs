﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.Data;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(WebApplication1Context))]
    partial class WebApplication1ContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.27")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WebApplication1.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("WebApplication1.Models.AreaUnit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AreaId")
                        .HasColumnType("int")
                        .HasColumnName("AreaId");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int")
                        .HasColumnName("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("UnitId");

                    b.ToTable("AreaUnits");
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("AreaId")
                        .HasColumnType("int")
                        .HasColumnName("AreaId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<int?>("UnitId")
                        .HasColumnType("int")
                        .HasColumnName("UnitId");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("UnitId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("WebApplication1.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("WebApplication1.Models.AreaUnit", b =>
                {
                    b.HasOne("WebApplication1.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("WebApplication1.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Area");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("WebApplication1.Models.Location", b =>
                {
                    b.HasOne("WebApplication1.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId");

                    b.HasOne("WebApplication1.Models.Unit", "Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");

                    b.Navigation("Area");

                    b.Navigation("Unit");
                });
#pragma warning restore 612, 618
        }
    }
}
