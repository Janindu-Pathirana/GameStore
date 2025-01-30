namespace GameStore.Dtos;

public record class GameDto(
    int Id,
    string Name,
    string Genera,
    string Publisher,
    decimal Price,
    DateOnly ReleaseDate
);
