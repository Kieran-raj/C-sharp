namespace BuilderPattern.FluentBuilderInheritence
{
    public class PersonJobBuilder<T> : PersonInfoBuilder<PersonJobBuilder<T>>
        where T : PersonJobBuilder<T>
    {
        public T WorksAsA(string position)
        {
            Person.Position = position;
            return (T)this;
        }
    }
}
