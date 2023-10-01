using NUnit.Framework;

namespace Singleton.SingletonImplementation
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest()
        {
            // This will check that each instance is referentially equal
            var db = SingletonDatabase.Instance;
            var dbTwo = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(dbTwo)); // NUnit testing -> Is.SameAs() checks that the two objects are referentially the same.
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        }
    }
}
