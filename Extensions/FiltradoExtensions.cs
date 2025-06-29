namespace MiLinq.Extensions;

public static class FiltradoExtensions
{
    public static IEnumerable<T> MiWhere<T>(this IEnumerable<T> fuente, Func<T, bool> predicado)
    {
        foreach (var item in fuente)
        {
            if (predicado(item))
                yield return item;
        }
    }
}
