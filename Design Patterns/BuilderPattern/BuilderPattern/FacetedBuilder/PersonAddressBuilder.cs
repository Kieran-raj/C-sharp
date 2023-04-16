namespace BuilderPattern.FacetedBuilder
{
    public class PersonAddressBuilder : PersonBuilder
    {
        public PersonAddressBuilder(Person person)
        {
            this.Person = person;   
        }

        public PersonAddressBuilder At(string streetAddress)
        {
            Person.StreetAddress = streetAddress;
            return this;
        }

        public PersonAddressBuilder WithPostcode(string postCode)
        {
            Person.Postcode = postCode;
            return this;    
        }

        public PersonAddressBuilder In(string city)
        {
            Person.City = city;
            return this;
        }
    }
}
