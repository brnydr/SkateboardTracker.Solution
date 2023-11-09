﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkateboardApi.Models;

#nullable disable

namespace SkateboardTracker.Migrations
{
    [DbContext(typeof(SkateboardApiContext))]
    partial class SkateboardApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SkateboardApi.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SessionId");

                    b.ToTable("Sessions");

                    b.HasData(
                        new
                        {
                            SessionId = 1,
                            Date = new DateTime(2023, 11, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "Ed Benedict Skatepark"
                        },
                        new
                        {
                            SessionId = 2,
                            Date = new DateTime(2023, 10, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Location = "TRON"
                        });
                });

            modelBuilder.Entity("SkateboardApi.Models.Trick", b =>
                {
                    b.Property<int>("TrickId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Notes")
                        .HasColumnType("longtext");

                    b.Property<string>("Obstacle")
                        .HasColumnType("longtext");

                    b.Property<bool>("OnLock")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("TrickId");

                    b.ToTable("Tricks");

                    b.HasData(
                        new
                        {
                            TrickId = 1,
                            Description = "backside 360 pop shove-it with kickflip",
                            Name = "Treflip",
                            Notes = "siiick",
                            Obstacle = "street area, flatland",
                            OnLock = true
                        },
                        new
                        {
                            TrickId = 2,
                            Description = "nose ollie",
                            Name = "Nollie",
                            Notes = "bail",
                            Obstacle = "4 stair",
                            OnLock = false
                        },
                        new
                        {
                            TrickId = 3,
                            Description = "backside pop shuvit heelflip",
                            Name = "inward heel",
                            Notes = "safe",
                            Obstacle = "grass",
                            OnLock = false
                        });
                });

            modelBuilder.Entity("SkateboardApi.Models.TrickSession", b =>
                {
                    b.Property<int>("TrickSessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("TrickId")
                        .HasColumnType("int");

                    b.HasKey("TrickSessionId");

                    b.HasIndex("SessionId");

                    b.HasIndex("TrickId");

                    b.ToTable("JoinEntities");
                });

            modelBuilder.Entity("SkateboardApi.Models.TrickSession", b =>
                {
                    b.HasOne("SkateboardApi.Models.Session", "Session")
                        .WithMany("JoinEntities")
                        .HasForeignKey("SessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkateboardApi.Models.Trick", "Trick")
                        .WithMany("JoinEntities")
                        .HasForeignKey("TrickId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Session");

                    b.Navigation("Trick");
                });

            modelBuilder.Entity("SkateboardApi.Models.Session", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("SkateboardApi.Models.Trick", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
