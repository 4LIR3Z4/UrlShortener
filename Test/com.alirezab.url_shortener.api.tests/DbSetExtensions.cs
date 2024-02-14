using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace com.alirezab.url_shortener.api.tests;
public static class DbSetExtensions
{
    public static Task<T> FirstOrDefaultAsync<T>(this DbSet<T> dbSet, Expression<Func<T, bool>> predicate) where T : class
    {
        return dbSet.FirstOrDefaultAsync(predicate);
    }
}
