using System;

namespace GameStore.Entities;

public class Game
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required Genre? Genera { get; set; }
    public required int GeneraId { get; set; }
    public required string Publisher { get; set; }
    public required decimal Price { get; set; }
    public required DateOnly ReleaseDate { get; set; }
}
