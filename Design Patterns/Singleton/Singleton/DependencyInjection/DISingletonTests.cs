using Autofac;
using NUnit.Framework;

namespace Singleton.DependencyInjection
{
    [TestFixture]
    public class DISingletonTests
    {
        [Test]
        public void ConfigurablePopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] { "Alpha", "Gamma" };
            var tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));
        }

        [Test]
        public void DIPopulationTest()
        {
            var cb = new ContainerBuilder();
            cb.RegisterType<OrdinaryDatabase>().As<IDatabase>().SingleInstance(); 
            cb.RegisterType<ConfigurableRecordFinder>();

            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
            }
        }
    }
}
