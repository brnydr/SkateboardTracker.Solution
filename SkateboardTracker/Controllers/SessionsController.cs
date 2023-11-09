using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using SkateboardApi.Models; 
using Microsoft.AspNetCore.Authorization;

namespace SkateboardApi.Controllers
{
  [Authorize]
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
      if ( location == null)
      {
       return await query.Include(entry=>entry.JoinEntities)
                          .ThenInclude(join=>join.Trick)
                          .ToListAsync();
      } 
      else 
      {
        return await query.Where(entry=>entry.Location ==location)
                          .Include(entry => entry.JoinEntities)
                          .ThenInclude(join=>join.Trick).ToListAsync();

        
      }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Session>> GetSession(int id)
    { 
      
      IQueryable<Session> session = _db.Sessions.AsQueryable().Where(entry => entry.SessionId == id);


    if (session == null)
      {
        return NotFound();
      }
      else 
      {
        return await session.Include(entry => entry.JoinEntities).ThenInclude(join=>join.Trick).FirstOrDefaultAsync();
      }
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
        _db.JoinEntities.Add(JoinEntity);

        // Save changes to persist the enrollment
        await _db.SaveChangesAsync();

        return Ok("Trick added.");
    }
  }
}

