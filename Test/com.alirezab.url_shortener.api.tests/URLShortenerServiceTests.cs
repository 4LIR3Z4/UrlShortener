using com.alirezab.url_shortener.api.Application.Services;
using com.alirezab.url_shortener.api.Domain.Models;
using com.alirezab.url_shortener.api.Infra;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Linq.Expressions;

namespace com.alirezab.url_shortener.api.tests;

public class URLShortenerServiceTests
{
    /*Scenario: Given an encoded string of a valid short URL, the service returns the corresponding URL object.*/
    [Fact]
    public async Task GetByEncodedString_ReturnsOkResult_WhenEncodedStringIsValid()
    {
        // Arrange
        var mockSet = new Mock<DbSet<URL>>();
        var mockContext = new Mock<UrlShortenerContext>();
        mockContext.Setup(context => context.ShortURLs.FindAsync(It.IsAny<string>()))
            .ReturnsAsync(new URL { Id = 1, OriginalUrl = "https://example.com", IsActive = true });

        var service = new URLShortenerService(mockContext.Object);
        string encodedString = "valid-encoded-string";

        // Act
        var result = await service.GetByEncodedString(encodedString);

        // Assert
        result.Match(
         success =>
         {
             success.Should().NotBeNull();
             success.Id.Should().Be(1);
             success.OriginalUrl.Should().Be("https://example.com");
             success.IsActive.Should().BeTrue();
         },
         failure => Assert.Fail()
     );

    }
    /*Scenario: Given an encoded string of an invalid short URL, the service returns a NotFoundResult.*/
    [Fact]
    public async Task GetByEncodedString_ReturnsNotFoundResult_WhenEncodedStringIsInvalid()
    {
        // Arrange
        var mockContext = new Mock<UrlShortenerContext>();
        mockContext.Setup(context => context.ShortURLs.FindAsync(It.IsAny<string>()))
            .ReturnsAsync((URL?)null);

        var service = new URLShortenerService(mockContext.Object);
        string encodedString = "invalid-encoded-string";

        // Act
        var result = await service.GetByEncodedString(encodedString);

        // Assert
        result.Match(success =>
        {
            Assert.Fail();
        }, error =>
        {
            error.Should().BeEquivalentTo("Not Found");
        });
    }
    /*Scenario: Given an original URL of a valid short URL, the service returns the corresponding URL object.*/
    [Fact]
    public async Task GetByOriginalUrl_ReturnsOkResult_WhenOriginalUrlIsValid()
    {
        // Arrange
        var mockContext = new Mock<IUrlShortenerContext>();
        mockContext.Setup(context => context.ShortURLs.FirstOrDefaultAsync(It.IsAny<Expression<Func<URL, bool>>>()))
            .ReturnsAsync(new URL { Id = 1, OriginalUrl = "https://example.com", IsActive = true });

        var service = new URLShortenerService(mockContext.Object);
        string originalUrl = "https://example.com";

        // Act
        var result = await service.GetByOriginalUrl(originalUrl);

        // Assert
        result.Match(url =>
        {
            url.Should().NotBeNull();
            url.Id.Should().Be(1);
            url.OriginalUrl.Should().Be("https://example.com");
            url.IsActive.Should().BeTrue();
        }, error =>
        {
            Assert.Fail();
        });
    }
    /*Scenario: Given an original URL of an invalid short URL, the service returns a NotFoundResult.*/
    [Fact]
    public async Task GetByOriginalUrl_ReturnsNotFoundResult_WhenOriginalUrlIsInvalid()
    {
        // Arrange
        var mockContext = new Mock<UrlShortenerContext>();
        mockContext.Setup(context => context.ShortURLs.FirstOrDefaultAsync(It.IsAny<Expression<Func<URL, bool>>>()))
            .Returns<URL>(null);

        var service = new URLShortenerService(mockContext.Object);
        string originalUrl = "invalid-url";

        // Act
        var result = await service.GetByOriginalUrl(originalUrl);

        // Assert
        result.Match(success =>
        {
            Assert.Fail();
        }
        , error =>
        {
            error.Should().BeEquivalentTo("Not Found");
        });
    }
}
