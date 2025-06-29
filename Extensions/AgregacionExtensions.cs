namespace MiLinq.Extensions;

public static class AgregacionExtensions
{
    public static int MiSum(this IEnumerable<int> fuente)
    {
        int suma = 0;
        foreach (var item in fuente)
            suma += item;

        return suma;
    }
    public static int MiSum<T>(this IEnumerable<T> fuente, Func<T, int> selector)
    {
        int suma = 0;

        foreach (var item in fuente)
        {
            int valor = selector(item);
            suma += valor;
        }
        return suma;
    }
    public static double MiAverage(this IEnumerable<int> fuente)
    {
        int suma = 0;
        int cantidad = 0;

        foreach (var item in fuente)
        {
            suma += item;
            cantidad++;
        }
        if (cantidad == 0)
            throw new InvalidOperationException("Secuencia vacía. No se puede calcular promedio.");

        double promedio = (double)suma / cantidad;
        return promedio;
    }
    public static double MiAverage<T>(this IEnumerable<T> fuente, Func<T, int> selector)
    {
        int suma = 0;
        int cantidad = 0;

        foreach (var item in fuente)
        {
            int valor = selector(item);
            suma += valor;
            cantidad++;
        }

        if (cantidad == 0)
            throw new InvalidOperationException("Secuencia vacía. No se puede calcular promedio.");

        double promedio = (double)suma / cantidad;
        return promedio;
    }
    public static T MiMax<T>(this IEnumerable<T> fuente) where T : IComparable<T>
    {
        using var enumerador = fuente.GetEnumerator();

        if (!enumerador.MoveNext())
            throw new InvalidOperationException("Secuencia vacía. No se puede calcular el máximo.");

        T max = enumerador.Current;

        while (enumerador.MoveNext())
        {
            T actual = enumerador.Current;

            if (actual.CompareTo(max) > 0)
                max = actual;
        }
        return max;
    }
    public static TSource MiMax<TSource, TResult>(this IEnumerable<TSource> fuente, Func<TSource, TResult> selector) where TResult : IComparable<TResult>
    {
        using var enumerador = fuente.GetEnumerator();

        if (!enumerador.MoveNext())
            throw new InvalidOperationException("Secuencia vacía. No se puede calcular el máximo.");

        TSource maxElemento = enumerador.Current;
        TResult maxValor = selector(maxElemento);

        while (enumerador.MoveNext())
        {
            TSource actualElemento = enumerador.Current;
            TResult actualValor = selector(actualElemento);

            if (actualValor.CompareTo(maxValor) > 0)
            {
                maxElemento = actualElemento;
                maxValor = actualValor;
            }
        }
        return maxElemento;
    }
    public static T MiMin<T>(this IEnumerable<T> fuente) where T : IComparable<T>
    {
        using var enumerador = fuente.GetEnumerator();

        if (!enumerador.MoveNext())
            throw new InvalidOperationException("Secuencia vacía. No se puede calcular el mínimo.");

        T minimo = enumerador.Current;

        while (enumerador.MoveNext())
        {
            T actual = enumerador.Current;

            if (actual.CompareTo(minimo) < 0)
                minimo = actual;
        }
        return minimo;
    }
    public static TSource MiMin<TSource, TResult>(this IEnumerable<TSource> fuente, Func<TSource, TResult> selector) where TResult : IComparable<TResult>
    {
        using var enumerador = fuente.GetEnumerator();

        if (!enumerador.MoveNext())
            throw new InvalidOperationException("Secuencia vacía. No se puede calcular el mínimo.");

        TSource minimoElemento = enumerador.Current;
        TResult minimoValor = selector(minimoElemento);

        while (enumerador.MoveNext())
        {
            TSource actualElemento = enumerador.Current;
            TResult actualValor = selector(actualElemento);

            if (actualValor.CompareTo(minimoValor) < 0)
            {
                minimoElemento = actualElemento;
                minimoValor = actualValor;
            }
        }
        return minimoElemento;
    }
    public static int MiCount<T>(this IEnumerable<T> fuente, Func<T, bool> predicado)
    {
        int contador = 0;

        foreach (var item in fuente)
        {
            if (predicado(item))
                contador++;
        }
        return contador;
    }
    public static int MiCount<T>(this IEnumerable<T> fuente)
    {
        int contador = 0;
        foreach (var item in fuente)
            contador++;

        return contador;
    }
}
