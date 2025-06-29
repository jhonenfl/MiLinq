namespace MiLinq.Extensions;

public static class ProyeccionExtensions
{
    public static IEnumerable<TResult> MiSelect<T, TResult>(this IEnumerable<T> fuente, Func<T, TResult> selector)
    {
        foreach (var item in fuente)
            yield return selector(item);
    }
}
