using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeRouletteAPI.Models
{
    public class Anime
    {
        [Key]
        public int AnimeID { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Release { get; set; }
        public string Studio { get; set; }
        public string ImgPath { get; set; }

        //Setting fk restraints
        //One anime can have multiple categories
        //Using navigation property, virtual one 
        [ForeignKey("Category")]
        public virtual List<Category> Categories { get; set; }
    }
}
