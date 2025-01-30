namespace GameStore.Dtos;

public record class UpdateDto(
    string? Name,
    string? Genera,
    string? Publisher,
    decimal? Price,
    DateOnly? ReleaseDate
);
