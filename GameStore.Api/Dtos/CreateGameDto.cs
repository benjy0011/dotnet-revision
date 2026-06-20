using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record CreateGameDto(
    [Required]
    [StringLength(50)] // 50 chars
    string Name,

    [Required]
    [StringLength(20)]
    string Genre,

    [Required]
    [Range(1, 999)]
    decimal Price,

    [Required]
    DateOnly ReleaseDate
);