using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeRouletteAPI.Models
{
    public class DTO
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Title")]
        public string AnimeTitle { get; set; }
        [ForeignKey("Genre")]
        public string AnimeGenre { get; set; }
        public virtual IEnumerable<Anime> Animes { get; set; }
        public virtual IEnumerable<Category> Category { get; set; }
    }
}
