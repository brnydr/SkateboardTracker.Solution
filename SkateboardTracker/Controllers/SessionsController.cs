using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkateboardApi.Models;

namespace SkateboardApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class SessionsController : ControllerBase
  {
    private readonly SkateboardApiContext _db; 
    public SessionsController(SkateboardApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Session>>> Get(string location)
    {
      IQueryable<Session> query = _db.Sessions.AsQueryable();

      if (location != null)
      {
        query = query.Where(entry => entry.Location == location);
                    
     
      }

      return await query.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Session>> GetSession(int id)
    {
      Session session = await _db.Sessions.FindAsync(id);

      if (session == null)
      {
        return NotFound();
      }

      return session;
    }



    [HttpPost("addTrick")]
    public async Task<IActionResult> AddingTricksToSession([FromQuery] int sessionId, [FromQuery] int trickId)
    {
        // Validation: Check if the student and course exist
        Session session = await _db.Sessions.FindAsync(sessionId);
        Trick trick = await _db.Tricks.FindAsync(trickId);

        if (trick == null || session == null)
        {
            return NotFound("No tricks found.");
        }

        // Create the StudentCourse join entity
        TrickSession JoinEntity = new TrickSession
        {
            SessionId = sessionId,
            TrickId = trickId
        };

        // Add the enrollment to the database
        _db.TrickSessions.Add(JoinEntity);

        // Save changes to persist the enrollment
        await _db.SaveChangesAsync();

        return Ok("Trick added.");
    }
  }
}