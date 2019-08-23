## Pruebas de interacción

Descargue el repositorio actual de la siguiente ruta: `https://github.com/omsanchezo/integration_kata.git`

En el proyecto  `foofactory` agregue los siguiente archivos

```csharp
    ## Foo.css
    public class Foo
    {
        public string Name { get; set; }
    }
```

```csharp
    ## IFooFactory.cs
    public interface IFooFactory
    {
        Foo GetById(int id);
    }
```

```csharp
    ## IFooFactory.cs
    public interface IFooFactory
    {
        Foo GetById(int id);
    }
```
```csharp
    ## Bar.cs
    public class Bar
    {
        public void Execute()
        {
            throw new NotImplementedException();
        }
    }
```


