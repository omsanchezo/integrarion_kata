using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace foofactory.tests
{

    class BarTests
    {

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

    }

    class FooMock : IFoo
    {
        public string Name { get; set; }

        public void DoSomething()
        {
            throw new NotImplementedException();
        }
    }
}
