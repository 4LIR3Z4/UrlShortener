using com.alirezab.url_shortener.api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace com.alirezab.url_shortener.api.Infra;
public class UrlShortenerContext(DbContextOptions options) : DbContext(options), IUrlShortenerContext
{
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    public DbSet<URL> ShortURLs { get; set; }
}
