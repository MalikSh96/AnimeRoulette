using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AnimeRouletteAPI.Models
{
    public class AppUser
    {
        [Key]
        public int ID { get; set; }
        [Required]
        //Guid = globally unique identifier -- resembles "unique" keyword from sql
        public Guid Email { get; set; }
        [Required]
        public string Password { get; set; }
        public bool Role { get; set; }

    }
}
