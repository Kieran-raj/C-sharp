namespace BuilderPattern.FluentBuilderInheritence
{
    public class PersonInfoBuilder<T> : PersonBuilder
        where T : PersonInfoBuilder<T>
    {
        public T Called(string name)
        {
            Person.Name = name;
            return (T)this;
        }
    }
}
