namespace GameStore.Dtos;

public record class CrateGameDto(
    string Name,
    string Genera,
    string Publisher,
    decimal Price,
    DateOnly ReleaseDate
);
