namespace com.alirezab.url_shortener.api.Domain.Common;

public class Result<T>
{
    public bool Success { get; private set; }
    public T? Value { get; private set; }
    public Error Error { get; private set; }
    private Result(bool success, T? value, Error error)
    {
        Success = success;
        Value = value;
        Error = error;
    }
    public static Result<T> Ok(T value)
    {
        return new Result<T>(true, value, Error.None);
    }

    public static Result<T> Fail(Error error)
    {
        return new Result<T>(false, default, error);
    }
    public R Match<R>(Func<T, R> successHandler, Func<Error, R> errorHandler)
    {
        if (Success)
        {
            return successHandler(Value!); // Use ! to assert non-null value
        }
        else
        {
            return errorHandler(Error);
        }
    }
}