﻿namespace com.alirezab.url_shortener.api.Domain.Common;
public sealed record Error(string Code, string Description)
{
    public static readonly Error None = new(string.Empty, string.Empty);

    public override string? ToString()
    {
        return Description;
    }
}
