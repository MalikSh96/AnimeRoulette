using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeRouletteAPI.Models
{
    //This will inherit from DbContext, this is our db handler
    public class AnimeDB : DbContext
    {
        //Every time you create a Db context class, you need an emptry constructor
        //Since we are using Core, we need dependency injection
        //Which also will invoke base class constructor
        public AnimeDB(DbContextOptions<AnimeDB> options) : base(options)
        {
           
        }
        public DbSet<Anime> Animes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> Users { get; set; }
        public DbSet<AnimeCategory> AnimeCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Anime>()
            //    .HasMany(anime => anime.Categories)
            //    .WithMany(category => category.Animes);

            //modelBuilder.Entity<Category>()
            //    .HasOne(cat => cat.Anime)
            //    .WithMany(a => a.Categories);

            //ac is short for anime categories, a = anime, c = category
            modelBuilder.Entity<AnimeCategory>()
                .HasKey(ac => new { ac.AnimeId, ac.CategoryName });
            modelBuilder.Entity<AnimeCategory>()
                .HasOne(ac => ac.Anime)
                .WithMany(a => a.AnimeCategories)
                .HasForeignKey(ac => ac.AnimeId);
            modelBuilder.Entity<AnimeCategory>()
                .HasOne(ac => ac.Category)
                .WithMany(c => c.AnimeCategories)
                .HasForeignKey(ac => ac.CategoryName);
            //Link used
            //h-ttps://www.learnentityframeworkcore.com/configuration/many-to-many-relationship-configuration
            //58.25
            //h-ttps://www.youtube.com/watch?v=W1sxepfIMRM&ab_channel=.NETFoundation
        }
    }
}
