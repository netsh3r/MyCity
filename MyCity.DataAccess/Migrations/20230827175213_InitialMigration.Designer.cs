﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyCity.DataAccess;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyCity.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230827175213_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MyCity.DataAccess.Entities.Location", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<long?>("PointId")
                        .HasColumnType("bigint");

                    b.Property<TimeOnly?>("WorkTimeEnd")
                        .HasColumnType("time without time zone");

                    b.Property<TimeOnly?>("WorkTimeStart")
                        .HasColumnType("time without time zone");

                    b.HasKey("Id");

                    b.HasIndex("PointId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("MyCity.DataAccess.Entities.Point", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("X")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Y")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Points");
                });

            modelBuilder.Entity("MyCity.DataAccess.Entities.Route", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("StartRoutePointId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("MyCity.DataAccess.Entities.RoutePoints", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("NextRoutePointId")
                        .HasColumnType("bigint");

                    b.Property<long>("PointId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("NextRoutePointId");

                    b.HasIndex("PointId");

                    b.ToTable("RoutePoints");
                });

            modelBuilder.Entity("MyCity.DataAccess.Entities.Location", b =>
                {
                    b.HasOne("MyCity.DataAccess.Entities.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId");

                    b.Navigation("Point");
                });

            modelBuilder.Entity("MyCity.DataAccess.Entities.RoutePoints", b =>
                {
                    b.HasOne("MyCity.DataAccess.Entities.RoutePoints", "NextRoutePoint")
                        .WithMany()
                        .HasForeignKey("NextRoutePointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MyCity.DataAccess.Entities.Point", "Point")
                        .WithMany()
                        .HasForeignKey("PointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("NextRoutePoint");

                    b.Navigation("Point");
                });
#pragma warning restore 612, 618
        }
    }
}