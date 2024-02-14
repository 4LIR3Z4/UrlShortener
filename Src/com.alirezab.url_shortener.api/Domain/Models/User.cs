namespace com.alirezab.url_shortener.api.Domain.Models;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    ICollection<URL>? URLs { get; set; } = new List<URL>();
}
