using System.ComponentModel.DataAnnotations;


namespace SkateboardApi.Models;

public class Session 
{
  public int SessionId {get; set;}
  [Required]
  public string Location {get; set;}
  public DateTime Date {get; set;}
  public List<TrickSession> JoinEntities {get; set;}

}

