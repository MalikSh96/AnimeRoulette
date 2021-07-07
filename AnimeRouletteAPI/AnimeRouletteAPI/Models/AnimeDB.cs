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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasOne(cat => cat.Anime)
                .WithMany(a => a.Categories);
        }
    }
}
