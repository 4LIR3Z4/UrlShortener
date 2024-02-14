using System.Text;

namespace com.alirezab.url_shortener.api.Application.Common.Helpers;

public interface IShortUrlHelper
{
    public string Encode(int numberToEncode);
    public int Decode(string stringToDecode);
}