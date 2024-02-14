using com.alirezab.url_shortener.api.Domain.Common;
using com.alirezab.url_shortener.api.Domain.Common.Errors;
using com.alirezab.url_shortener.api.Domain.Contracts;
using com.alirezab.url_shortener.api.Domain.Models;
using com.alirezab.url_shortener.api.Infra;
using Microsoft.EntityFrameworkCore;

namespace com.alirezab.url_shortener.api.Application.Services;
public class URLShortenerService(IUrlShortenerContext context, IShortUrlHelper shortUrlHelper, IUrlValidator urlValidator) : IURLShortenerService
{
    private readonly IUrlShortenerContext _context = context;
    private readonly IShortUrlHelper _shortUrlHelper = shortUrlHelper;
    private readonly IUrlValidator _urlValidator = urlValidator;

    public async Task<Result<URL>> GetById(int id)
    {
        var temp = await _context.ShortURLs.FindAsync(id);
        if (temp != null)
        {
            return Result<URL>.Ok(temp);
        }
        return Result<URL>.Fail(URLShortenerServiceErrors.URLNotFound);
    }

    public async Task<Result<URL>> GetByEncodedString(string encodedString)
    {
        var temp = await _context.ShortURLs.FindAsync(_shortUrlHelper.Decode(encodedString));
        if (temp != null)
        {
            return Result<URL>.Ok(temp);
        }
        return Result<URL>.Fail(URLShortenerServiceErrors.URLNotFound);
    }

    public async Task<Result<URL>> GetByOriginalUrl(string originalUrl)
    {
        var temp = await _context.ShortURLs.FirstOrDefaultAsync(shortUrl => shortUrl.OriginalUrl == originalUrl);
        if (temp != null)
        {
            return Result<URL>.Ok(temp);
        }
        return Result<URL>.Fail(URLShortenerServiceErrors.URLNotFound);
    }

    public async Task<Result<string>> Create(URL shortUrl)
    {
        if (shortUrl is null)
        {
            throw new ArgumentNullException(nameof(shortUrl));
        }
        if (!_urlValidator.IsValidUrl(shortUrl.OriginalUrl))
        {
            return Result<string>.Fail(URLShortenerServiceErrors.InValidURL);
        }
        _context.ShortURLs.Add(shortUrl);
        await _context.SaveChangesAsync();

        return Result<string>.Ok(_shortUrlHelper.Encode(shortUrl.Id));
    }
}