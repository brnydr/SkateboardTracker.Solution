using System.ComponentModel.DataAnnotations;

namespace SkateboardApi.Models;

public class Trick
{
  public int TrickId {get; set;}
  [Required]
  public string Name {get; set;}
  public string Description {get; set;}
  public string Obstacle {get; set;}
  public bool OnLock {get; set;}
  public string Notes {get; set;}
  public List<TrickSession> JoinEntities {get; set;}

}