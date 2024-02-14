using com.alirezab.url_shortener.api.Domain.Common;
using com.alirezab.url_shortener.api.Domain.Models;

namespace com.alirezab.url_shortener.api.Domain.Contracts;
public interface IURLShortenerService
{
    Task<Result<URL>> GetById(int id);

    Task<Result<URL>> GetByEncodedString(string encodedString);

    Task<Result<URL>> GetByOriginalUrl(string originalUrl);

    Task<Result<string>> Create(URL shortUrl);
}

