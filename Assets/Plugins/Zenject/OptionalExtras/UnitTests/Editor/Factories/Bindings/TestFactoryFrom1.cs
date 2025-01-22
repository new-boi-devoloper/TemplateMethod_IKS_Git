using NUnit.Framework;
using Assert = ModestTree.Assert;

namespace Zenject.Tests.Bindings
{
    [TestFixture]
    public class TestFactoryFrom1 : ZenjectUnitTestFixture
    {
        [Test]
        public void TestSelf()
        {
            Container.BindFactory<string, Foo, Foo.Factory>().NonLazy();

            Assert.IsEqual(Container.Resolve<Foo.Factory>().Create("asdf").Value, "asdf");
        }

        [Test]
        public void TestConcrete()
        {
            Container.BindFactory<string, IFoo, IFooFactory>().To<Foo>().NonLazy();

            var ifoo = Container.Resolve<IFooFactory>().Create("asdf");

            Assert.IsNotNull(ifoo);
            Assert.IsEqual(((Foo)ifoo).Value, "asdf");
        }

        private interface IFoo
        {
        }

        private class IFooFactory : PlaceholderFactory<string, IFoo>
        {
        }

        private class Foo : IFoo
        {
            public Foo(string value)
            {
                Value = value;
            }

            public string Value { get; }

            public class Factory : PlaceholderFactory<string, Foo>
            {
            }
        }
    }
}