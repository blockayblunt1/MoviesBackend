using System.ComponentModel.DataAnnotations;

namespace MovieBackend.Dtos;

public class CreateMovieDto
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? Genre { get; set; }

    [Range(1, 5)]
    public int? Rating { get; set; }

    // Optional poster image URL
    public string? PosterImage { get; set; }
}
