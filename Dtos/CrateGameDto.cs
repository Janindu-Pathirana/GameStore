using System.ComponentModel.DataAnnotations;

namespace GameStore.Dtos;

public record class CrateGameDto(
    [Required] [StringLength(50)] string Name,
    [Required] [StringLength(20)] string Genera,
    [Required] [StringLength(20)] string Publisher,
    [Required] [Range(1, 100)] decimal Price,
    [Required] DateOnly ReleaseDate
);
