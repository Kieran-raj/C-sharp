namespace Singleton.Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var instance = func();
            var instance2 = func();

            return instance.Equals(instance2);
        }
    }
}
