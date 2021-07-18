using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimeRouletteAPI.Models;

namespace AnimeRouletteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimesController : ControllerBase
    {
        private readonly AnimeDB _context;

        public AnimesController(AnimeDB context)
        {
            _context = context;
        }

        // GET: api/Animes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Anime>>> GetAnimes()
        {
            return await _context.Animes.ToListAsync();
        }

        // GET: api/Animes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Anime>> GetAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);

            if (anime == null)
            {
                return NotFound();
            }

            return anime;
        }

        // PUT: api/Animes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnime(int id, Anime anime)
        {
            if (id != anime.AnimeID)
            {
                return BadRequest();
            }

            _context.Entry(anime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Animes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Anime>> PostAnime(Anime anime)
        {
            //If the title of a given anime already exists
            if (_context.Animes.Any(a => a.Title == anime.Title))
            {
                throw new ArgumentException("Title Already Exist");
            }
            var dbCategories = _context.Categories.AsNoTracking().ToList();
            var animeCategories = anime.AnimeCategories; //POST input
            //looping our category db table for its categories/genres
            foreach (var category in dbCategories)
            {
                //looping through categories/genres IN anime input
                //item is just a counter
                //for (var item = 0; item <= animeCategories.Count(); item++)
                //{
                foreach (var item in animeCategories)
                {
                    //Below throws NULL value currently, since there is no value for new entries
                    var itemToAdd = animeCategories
                        .Where(x => x.CategoryName.Equals(category.Genre))
                        .FirstOrDefault();

                    var comparingInput = dbCategories
                        .Where(c => c.CatID == itemToAdd.CategoryId)
                        .FirstOrDefault();
                    
                    //compare input with db table entries, if they are NOT equal
                    //comparing the db table entry WITH the post of anime
                    if (!category.Genre.Equals(comparingInput))
                    {
                        dbCategories.Add(comparingInput);
                        //animeCategories.Add(itemToAdd);
                    }
                }
            }
            _context.Animes.Add(anime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnime", new { id = anime.AnimeID }, anime);
        }

        // DELETE: api/Animes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnime(int id)
        {
            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }

            _context.Animes.Remove(anime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeExists(int id)
        {
            return _context.Animes.Any(e => e.AnimeID == id);
        }
    }
}
