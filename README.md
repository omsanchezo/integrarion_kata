
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
        IList<IFoo> GetAll();
        void Save(IFoo foo);
    }
```

```csharp
    ## Bar.cs
    public class Bar
    {
        public IList<IFoo> Execute()
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

> Confirmar que la clase Bar ejecuta el método DoSomething para las clases IFoo con Name='TheOne' pero no para cualquier otra

```csharp
## BarTest.cs
[Test]
public void Execute_CallSomethingForTheOne()
{
   IList<IFoo> fooListMock = new List<IFoo>();

   var mockFooTheOne = new Mock<IFoo>();
   mockFooTheOne.Setup(x => x.Name).Returns("TheOne");

   var mockFooAnother = new Mock<IFoo>();
   mockFooAnother.Setup(x => x.Name).Returns("AnotherOne");

   fooListMock.Add(mockFooTheOne.Object);
   fooListMock.Add(mockFooAnother.Object);

   // Arrange
   Bar classUnderTest = new Bar();
   var factoryMock = new Mock<IFooFactory>();
   factoryMock.Setup(x => x.GetAll()).Returns(fooListMock);
   classUnderTest.FooFactory = factoryMock.Object;

   // Act
   classUnderTest.Execute();

   // Assert
   mockFooTheOne.Verify(x => x.DoSomething(), Times.Once());
   mockFooAnother.Verify(x => x.DoSomething(), Times.Never());
}
```
Modificar la implementacion 

```csharp
##Bar.css
public IList<IFoo> Execute()
 {
     IList<IFoo> allFoo = this.FooFactory.GetAll();
     foreach (var theOne in allFoo.Where(x=>x.Name == "TheOne"))
             theOne.DoSomething();
     return allFoo;
}
```

> Confirmar que toda clases "TheOne" son guardadas en el IFooFactory.Save

```csharp
## BarTest.cs
[Test]
public void Execute_CallSomethingForTheOne()
{
	...
	// Assert
	factoryMock.Verify(x=>x.Save(mockFooTheOne.Object), Times.Once))
	factoryMock.Verify(x => x.Save(mockFooAnother.Object), Times.Once))
}
```
```csharp
##Bar.css
public IList<IFoo> Execute()
 {
     IList<IFoo> allFoo = this.FooFactory.GetAll();
     foreach (var theOne in allFoo.Where(x => x.Name == "TheOne"))
     {
         theOne.DoSomething();
         this.FooFactory.Save(theOne);
     }
     return allFoo;
}
```
