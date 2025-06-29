namespace MiLinq.Extensions;

public static class BúsquedaExtensions
{
    public static bool MiContains<T>(this IEnumerable<T> fuente, T valor)
    {
        foreach (var item in fuente)
        {
            if (EqualityComparer<T>.Default.Equals(item, valor))
                return true;
        }
        return false;
    }
    public static T? MiFirst<T>(this IEnumerable<T> fuente)
    {
        foreach (var item in fuente)
            return item;

        return default;
    }
    public static T MiFirst<T>(this IEnumerable<T> fuente, Func<T, bool> predicado)
    {
        foreach (var item in fuente)
        {
            if (predicado(item))
                return item;
        }
        throw new InvalidOperationException("No se encontró ninguno elemento que cumpla la condición.");
    }
    public static T? MiFirstOrDefault<T>(this IEnumerable<T> fuente, Func<T, bool> predicado)
    {
        foreach (var item in fuente)
        {
            if (predicado(item))
                return item;
        }
        return default;
    }
    public static bool MiAny<T>(this IEnumerable<T> fuente, Func<T, bool> predicado)
    {
        foreach (var item in fuente)
        {
            if (predicado(item))
                return true;
        }
        return false;
    }
    public static bool MiALl<T>(this IEnumerable<T> fuente, Func<T, bool> predicado)
    {
        foreach (var item in fuente)
        {
            if (!predicado(item))
                return false;
        }
        return true;
    }
    public static IEnumerable<T> MiTake<T>(this IEnumerable<T> fuente, int cantidad)
    {
        int contador = 0;

        foreach (var item in fuente)
        {
            if (contador++ < cantidad)
                yield return item;
            else
                yield break;
        }
    }
    public static IEnumerable<T> MiSkip<T>(this IEnumerable<T> fuente, int cantidad)
    {
        int contador = 0;

        foreach (var item in fuente)
        {
            if (contador++ < cantidad)
                continue;
            else
                yield return item;
        }
    }
}
