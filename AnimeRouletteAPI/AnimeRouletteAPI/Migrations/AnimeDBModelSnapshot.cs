﻿// <auto-generated />
using System;
using AnimeRouletteAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AnimeRouletteAPI.Migrations
{
    [DbContext(typeof(AnimeDB))]
    partial class AnimeDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AnimeRouletteAPI.Models.Anime", b =>
                {
                    b.Property<int>("AnimeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImgPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Release")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Studio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AnimeID");

                    b.ToTable("Animes");
                });

            modelBuilder.Entity("AnimeRouletteAPI.Models.AnimeCategory", b =>
                {
                    b.Property<int>("AnimeId")
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AnimeId", "CategoryName");

                    b.HasIndex("CategoryName");

                    b.ToTable("AnimeCategories");
                });

            modelBuilder.Entity("AnimeRouletteAPI.Models.AppUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<Guid>("Email")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Role")
                        .HasColumnType("bit");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AnimeRouletteAPI.Models.Category", b =>
                {
                    b.Property<string>("Genre")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CatID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Genre");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("AnimeRouletteAPI.Models.AnimeCategory", b =>
                {
                    b.HasOne("AnimeRouletteAPI.Models.Anime", "Anime")
                        .WithMany("AnimeCategories")
                        .HasForeignKey("AnimeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AnimeRouletteAPI.Models.Category", "Category")
                        .WithMany("AnimeCategories")
                        .HasForeignKey("CategoryName")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anime");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("AnimeRouletteAPI.Models.Anime", b =>
                {
                    b.Navigation("AnimeCategories");
                });

            modelBuilder.Entity("AnimeRouletteAPI.Models.Category", b =>
                {
                    b.Navigation("AnimeCategories");
                });
#pragma warning restore 612, 618
        }
    }
}
