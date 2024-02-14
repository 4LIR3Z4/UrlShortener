namespace com.alirezab.url_shortener.api.Application.Common.Helpers;

public class UrlValidator : IUrlValidator
{
    public bool IsValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out Uri? createdUrl) && 
            (createdUrl.Scheme == Uri.UriSchemeHttp || createdUrl.Scheme == Uri.UriSchemeHttps);
    }
}