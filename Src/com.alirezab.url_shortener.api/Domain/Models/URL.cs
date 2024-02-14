namespace com.alirezab.url_shortener.api.Domain.Models;
public class URL
{
    public int Id { get; set; }
    public string OriginalUrl { get; set; } = null!;
    public DateTime? ExpireDate { get; set; }
    public bool IsActive { get; set; }
    //public string? Password {  get; set; }
    //public User? User { get; set; }
    //public int? UserId {  get; set; }
}