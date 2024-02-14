using com.alirezab.url_shortener.api.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace com.alirezab.url_shortener.api.Infra;

public interface IUrlShortenerContext
{
    public DbSet<URL> ShortURLs { get; set; }
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
