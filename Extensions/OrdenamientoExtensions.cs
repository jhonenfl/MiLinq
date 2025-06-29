namespace MiLinq.Extensions;

public static class OrdenamientoExtensions
{
    public static IEnumerable<T> MiOrderBy<T, TKey>(this IEnumerable<T> fuente, Func<T, TKey> clave) where TKey : IComparable<TKey>
    {
        var listaOrdenada = fuente.ToList();
        listaOrdenada.Sort((a, b) => clave(a).CompareTo(clave(b)));
        foreach (var item in listaOrdenada)
            yield return item;
    }
    public static Dictionary<TKey, List<T>> MiGroupBy<T, TKey>(this IEnumerable<T> fuente, Func<T, TKey> claveSelector)
    {
        Dictionary<TKey, List<T>> diccionario = new Dictionary<TKey, List<T>>();

        foreach (var item in fuente)
        {
            var clave = claveSelector(item);

            if (!diccionario.ContainsKey(clave))
                diccionario[clave] = new List<T>();

            diccionario[clave].Add(item);
        }
        return diccionario;
    }
}
