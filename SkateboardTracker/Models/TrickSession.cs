namespace SkateboardApi.Models;

public class TrickSession
{
  public int TrickSessionId {get; set; }
  public int SessionId {get; set;}
  public Session Session {get; set; }
  public int TrickId {get; set; }
  public Trick Trick {get; set;}
}