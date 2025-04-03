namespace GameStore.Models
{
  public class Game
  {
    public string? Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public int? ReleaseYear { get; set; }
    public string? Genre { get; set; }
    public string? Cover { get; set; }
  }
}
