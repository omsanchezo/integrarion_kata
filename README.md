## Pruebas de interacción

Descargue el repositorio actual de la siguiente ruta: `https://github.com/omsanchezo/integration_kata.git`

En el proyecto  `foofactory` agregue los siguiente archivos

```csharp
    ## Foo.css
    public interface IFoo
    {
        string Name { get; set; }
        void DoSomething();
    }
```

```csharp
    ## IFooFactory.cs
    public interface IFooFactory
    {
        IList<IFoo> GetAll(int id);
        void Save(IFoo foo);
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


