using System.ComponentModel.DataAnnotations;

namespace MovieBackend.Dtos;

public class UpdateMovieDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Genre { get; set; }

    [Range(1, 5)]
    public int? Rating { get; set; }

    public string? PosterImage { get; set; }
}
