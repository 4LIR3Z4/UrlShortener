namespace com.alirezab.url_shortener.api.Domain.Common.Errors;

public static class URLShortenerServiceErrors
{
    public static readonly Error InValidURL = new(
        "URL.Invalid", "Invalid Url");

    public static readonly Error URLNotFound = new(
        "URL.NotFound", "Url not found");
}
