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
        //h-ttps://www.learnentityframeworkcore.com/configuration/data-annotation-attributes/databasegenerated-attribute
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        //[ForeignKey("Category")]
        public virtual ICollection<AnimeCategory> AnimeCategories { get; set; }
    }
}