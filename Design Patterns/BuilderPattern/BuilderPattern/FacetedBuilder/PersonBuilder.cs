namespace BuilderPattern.FacetedBuilder
{
    public class PersonBuilder // facade
    {
        // reference object!
        protected Person Person = new Person();

        public PersonJobBuilder Works => new PersonJobBuilder(Person);

        public PersonAddressBuilder Lives => new PersonAddressBuilder(Person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.Person;
        }
    }
}
