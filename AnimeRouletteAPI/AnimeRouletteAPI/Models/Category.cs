using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeRouletteAPI.Models
{
    public class Category
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CatID { get; set; }

        //Setting fk restraints
        //[ForeignKey("Anime")]
        [Key]
        [Required]
        public string Genre { get; set; }

        //Using navigation property, virtual one
        public virtual ICollection<AnimeCategory> AnimeCategories { get; set; }
    }
}