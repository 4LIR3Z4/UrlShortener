namespace com.alirezab.url_shortener.api.tests;

public class URLShortenerServiceTests
{
    /*Scenario: Given an encoded string of a valid short URL, the service returns the corresponding URL object.*/
    [Fact]
    public async Task GetByEncodedString_ReturnsOkResult_WhenEncodedStringIsValid()
    {
        // Arrange
        

        // Act

        // Assert

    }
    /*Scenario: Given an encoded string of an invalid short URL, the service returns a NotFoundResult.*/
    [Fact]
    public async Task GetByEncodedString_ReturnsNotFoundResult_WhenEncodedStringIsInvalid()
    {
        // Arrange

        // Act

        // Assert
        
    }
    /*Scenario: Given an original URL of a valid short URL, the service returns the corresponding URL object.*/
    [Fact]
    public async Task GetByOriginalUrl_ReturnsOkResult_WhenOriginalUrlIsValid()
    {
        // Arrange

        // Act

        // Assert
        
    }
    /*Scenario: Given an original URL of an invalid short URL, the service returns a NotFoundResult.*/
    [Fact]
    public async Task GetByOriginalUrl_ReturnsNotFoundResult_WhenOriginalUrlIsInvalid()
    {
        // Arrange
        
        // Act

        // Assert
        
    }
}
