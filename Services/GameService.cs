using GameStore.Models;
using System.Text.Json;

namespace GameStore.Services
{
  public class GameService
  {
    private readonly string _filePath = Path.Combine(Directory.GetCurrentDirectory(), "games.json");

    public List<Game> GetAllGames()
    {
      var jsonData = File.ReadAllText(_filePath);
      var gameList = JsonSerializer.Deserialize<List<Game>>(jsonData) ?? new List<Game>();
      return gameList;
    }
  }
}
