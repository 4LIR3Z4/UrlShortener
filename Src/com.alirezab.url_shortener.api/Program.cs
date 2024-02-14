using com.alirezab.url_shortener.api.Application.Services;
using com.alirezab.url_shortener.api.Domain.Common.Dtos.URL;
using com.alirezab.url_shortener.api.Domain.Contracts;
using com.alirezab.url_shortener.api.Infra;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;

namespace com.alirezab.url_shortener.api;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        builder.Services.AddOutputCache();
        builder.Services.AddDbContext<IUrlShortenerContext, UrlShortenerContext>(
            options => options.UseSqlite("filename=shorturls.db")
            );
        builder.Services.AddScoped<IURLShortenerService, URLShortenerService>();
        builder.Services.AddScoped<IUrlValidator, UrlValidator>();
        builder.Services.AddScoped<IShortUrlHelper, ShortUrlHelper>();
        var app = builder.Build();
        app.UseOutputCache();

        var welcomeMessage = "Welcome";
        app.MapGet("/", () => welcomeMessage);


        var urlShortenerApi = app.MapGroup("/u");
        urlShortenerApi.MapGet("/{encodedString}", 
            [OutputCache] async (string encodedString, IURLShortenerService shortUrlService) =>
        {
            var result = await shortUrlService.GetByEncodedString(encodedString);
            return result.Match(success => Results.Ok(success.OriginalUrl), 
                error => Results.NotFound(error.ToString()));
            
        });

        urlShortenerApi.MapPost("/", async (CreateShortUrlRequestDto requestDto, IURLShortenerService shortUrlService) =>
        {
            var result = await shortUrlService.Create(new()
            {
                IsActive = true,
                OriginalUrl = requestDto.longUrl,
                ExpireDate = null
            });
            return result.Match(success => Results.Ok(success),
                error => Results.NotFound(error.ToString()));
        });

        app.Run();
    }
}