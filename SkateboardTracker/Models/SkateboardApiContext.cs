using Microsoft.EntityFrameworkCore;

namespace SkateboardApi.Models;

public class SkateboardApiContext : DbContext
{
  public DbSet<Trick> Tricks {get; set;}
  public DbSet<Session> Sessions {get; set;}
  public DbSet<TrickSession> TrickSessions {get; set;}

  public SkateboardApiContext(DbContextOptions<SkateboardApiContext> options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder builder)
  {
    builder.Entity<Trick>()
      .HasData(
        new Trick { TrickId=1, Name = "Treflip", Description = "backside 360 pop shove-it with kickflip", Obstacle = "street area, flatland", OnLock = true, Notes = "siiick" },
        new Trick { TrickId=2, Name = "Nollie", Description = "nose ollie", Obstacle = "4 stair", OnLock = false, Notes = "bail" },
        new Trick { TrickId=3, Name = "inward heel", Description = "backside pop shuvit heelflip", Obstacle = "grass", OnLock = null, Notes = "safe" }
      
      );

      builder.Entity<Session>()
        .HasData(
          new Session{ SessionId = 1, Location="Ed Benedict Skatepark", Date= new DateTime(2023,11, 4)},
          new Session{ SessionId = 2, Location = "TRON", Date = new DateTime(2023, 10, 30)}
        );
  } 
}