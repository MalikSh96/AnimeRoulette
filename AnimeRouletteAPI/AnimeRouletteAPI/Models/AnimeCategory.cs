using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeRouletteAPI.Models
{
    public class AnimeCategory
    {
        public int AnimeId { get; set; }
        public Anime Anime { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
