using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeRouletteAPI.Models
{
    public class AnimeCategory
    {
        public int AnimeId { get; set; }
        //public string AnimeTitle { get; set; }
        public Anime Anime { get; set; }
        //public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public Category Category { get; set; }
    }
}
