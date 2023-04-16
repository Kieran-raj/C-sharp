namespace BuilderPattern.FunctionalBuilder
{
    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorkAs(this PersonBuilder builder, string position)
        {
            return builder.Do(p => p.Position = position);
        }
    }
}
