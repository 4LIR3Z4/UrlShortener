using System.ComponentModel.DataAnnotations;

namespace com.alirezab.url_shortener.api.Domain.Common.Dtos.URL;

public class CreateShortUrlRequestDto
{
    [Required]
    public string longUrl { get; set; }
}
