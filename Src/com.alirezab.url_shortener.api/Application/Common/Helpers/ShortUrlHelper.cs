/*
 * ShortURL (https://github.com/delight-im/ShortURL)
 * Copyright (c) delight.im (https://www.delight.im/)
 * Licensed under the MIT License (https://opensource.org/licenses/MIT)
 */

using System.Text;

namespace com.alirezab.url_shortener.api.Application.Common.Helpers;
/**
 * ShortURL: Bijective conversion between natural numbers (IDs) and short strings
 *
 * ShortURL.Encode() takes an ID and turns it into a short string
 * ShortURL.Decode() takes a short string and turns it into an ID
 *
 * Features:
 * + large alphabet (51 chars) and thus very short resulting strings
 * + proof against offensive words (removed 'a', 'e', 'i', 'o' and 'u')
 * + unambiguous (removed 'I', 'l', '1', 'O' and '0')
 *
 * Example output:
 * 123456789 <=> pgK8p
 */
public class ShortUrlHelper : IShortUrlHelper
{

    private const string _alphabet = "23456789bcdfghjkmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ-_";
    private static readonly int _base = _alphabet.Length;

    public string Encode(int numberToEncode)
    {
        var sb = new StringBuilder();
        while (numberToEncode > 0)
        {
            sb.Insert(0, _alphabet.ElementAt(numberToEncode % _base));
            numberToEncode /= _base;
        }
        return sb.ToString();
    }

    public int Decode(string stringToDecode)
    {
        var num = 0;
        for (var i = 0; i < stringToDecode.Length; i++)
        {
            num = num * _base + _alphabet.IndexOf(stringToDecode.ElementAt(i));
        }
        return num;
    }
}
