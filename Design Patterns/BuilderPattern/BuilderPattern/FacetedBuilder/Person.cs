namespace BuilderPattern.FacetedBuilder
{
    public class Person
    {
        public string StreetAddress;
        public string City;
        public string Postcode;

        public string CompanyName;
        public string Position;
        public int AnnualIncome;

        public override string? ToString()
        {
            return $"{nameof(StreetAddress)}: {StreetAddress}, {nameof(City)}: {City}, {nameof(Postcode)}: {Postcode}, {nameof(CompanyName)}: {CompanyName}, {nameof(Postcode)}: {Position}, {nameof(AnnualIncome)}: {AnnualIncome}";
        }
    }
}
