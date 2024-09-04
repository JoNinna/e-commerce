namespace DoorDash.Models
{
  public class Client
  {
    public string ClientId { get; set; } //ex: Hannaford, Walgreens
    public string Status { get; set; } //ex: Open, Closed
  }

  public class ScaleRequest
  {
    public string ClientId { get; set; }
    public int Count { get; set; } //number increased for an increased request    
  }
}

