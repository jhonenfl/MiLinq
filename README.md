# MiLinq

Extensiones personalizadas de LINQ para C#  
📦 `Filtrado`, `Ordenamiento`, `Agregación`, `Búsqueda` y `Proyección` sin depender del espacio de nombres `System.Linq`.

---

## 🚀 ¿Qué es MiLinq?

**MiLinq** es una colección de métodos de extensión que replican la funcionalidad de LINQ usando solo `IEnumerable<T>` y funciones lambda.  
Ideal para aprender cómo funciona LINQ por dentro, o para ambientes donde necesitás **control total** sobre la ejecución diferida.

---

## ✨ Características

✅ Filtros: `MiWhere`  
✅ Ordenamientos: `MiOrderBy`  
✅ Transformaciones: `MiSelect`  
✅ Búsqueda: `MiFirst`, `MiAny`, `MiContains`  
✅ Agregaciones: `MiCount`, `MiSum`, `MiAverage`, `MiMin`, `MiMax`  
✅ Agrupamientos: `MiGroupBy`  
✅ Soporte para selectores (`Func<T, R>`)  
✅ Ejecución diferida con `yield return`  
✅ Implementado desde cero usando `IEnumerator<T>`

---

## 💡 Ejemplo de uso

```csharp
using MiLinq.Extensions;

var usuarios = new List<Usuario>
{
    new Usuario { Nombre = "Ana", Edad = 19 },
    new Usuario { Nombre = "Luis", Edad = 22 },
    new Usuario { Nombre = "Carlos", Edad = 17 }
};

// Filtro + ordenamiento + proyección
var mayoresOrdenados = usuarios
    .MiWhere(u => u.Edad >= 18)
    .MiOrderBy(u => u.Edad)
    .MiSelect(u => $"{u.Nombre} ({u.Edad})");

foreach (var linea in mayoresOrdenados)
{
    Console.WriteLine(linea);
}
