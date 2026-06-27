using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Dtos;

public record CreateGameDto(
    [Required]
    [StringLength(50)] // 50 chars
    string Name,

    [Required]
    [Range(1, 50)]
    int GenreId,

    [Required]
    [Range(1, 999)]
    decimal Price,

    [Required]
    DateOnly ReleaseDate
);