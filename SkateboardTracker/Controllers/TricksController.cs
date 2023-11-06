using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkateboardApi.Models;

namespace SkateboardApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class TricksController : ControllerBase
  {
    private readonly SkateboardApiContext _db;

    public TricksController(SkateboardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Trick>>> Get(string name, bool? onLock)
    {
      IQueryable<Trick> query = _db.Tricks.AsQueryable();

      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }

      if (onLock != null)
      { 
        query = query.Where(entry=>entry.OnLock == onLock);
      }

      return await query.ToListAsync();

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Trick>> GetTrick(int id)
    {
        Trick trick = await _db.Tricks.FindAsync(id);
        if (trick == null)
        {
            return NotFound();
        }

        return trick;
    }

    [HttpPost]
    public async Task<ActionResult<Trick>> Post(Trick trick)
    {
      _db.Tricks.Add(trick);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetTrick), new { id = trick.TrickId }, trick);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Trick trick)
    {
      if (id != trick.TrickId)
      {
        return BadRequest();
      }

      _db.Tricks.Update(trick);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TrickExists(id))
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

    private bool TrickExists(int id)
    {
      return _db.Tricks.Any(e => e.TrickId == id);
    }

     // DELETE: api/Tricks/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTrick(int id)
    {
      Trick trick = await _db.Tricks.FindAsync(id);
      if (trick == null)
      {
        return NotFound();
      }

      _db.Tricks.Remove(trick);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}