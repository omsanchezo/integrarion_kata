
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

## Agregar la clases de pruebas

En el proyecto `foofactory.tests` agregar la clase `BarTests.cs` 

> Primer requisito. Verificar que la clase Bar obtiene las clases de tipo IFoo y las regresa correctamente

Modificar la clase `Bar` de la siguiente manera

```csharp
public class Bar
{

    public IFooFactory FooFactory { get; set; }
    ...   
}
```

Codificar la siguiente prueba en la clase `BarTest`

```csharp
[Test]
public void Execute_GetThreeIFoo()
{
   // Arrange
   Bar classUnderTest = new Bar();
   // Act
   var allFoo =  classUnderTest.Execute();

   // Assert
   Assert.That(allFoo.Count, Is.EqualTo(3));
}
```

En el proyecto  `foofactory.test` instalar el nuget `Moq` y modificar la prueba como se muestra

```csharp
[Test]
        public void Execute_GetThreeIFoo()
        {
            IList<IFoo> fooListMock = new List<IFoo>();
            fooListMock.Add(new FooMock());
            fooListMock.Add(new FooMock());
            fooListMock.Add(new FooMock());

            // Arrange
            Bar classUnderTest = new Bar();
            var factoryMock = new Mock<IFooFactory>();
            factoryMock.Setup(x => x.GetAll()).Returns(fooListMock);
            classUnderTest.FooFactory = factoryMock.Object;

            // Act
            var allFoo =  classUnderTest.Execute();

            // Assert
            Assert.That(allFoo.Count, Is.EqualTo(3));
        }
```

Implementar el código en la clase `Bar`

```csharp
public class Bar
{
	...
    public IList<IFoo> Execute()
    {
        return this.FooFactory.GetAll();
    }
}
```
