namespace Prototype.DeepCopyInterfaces
{
    public class DeepCopy
    {
        public class Person : IPrototype<Person>
        {
            public string[] Names { get; set; }

            public Address Address { get; set; }

            public Person(string[] names, Address address)
            {
                this.Address = address ?? throw new ArgumentNullException(nameof(address));
                this.Names = names ?? throw new ArgumentNullException(nameof(names));
            }

            public override string? ToString()
            {
                return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
            }

            public Person DeepCopy()
            {
                return new Person(Names, Address.DeepCopy());  
            }

            public Person(Person other)
            {
                Names = other.Names;
                Address = new Address(other.Address);
            }
        }

        public class Address : IPrototype<Address>
        {
            public string StreetName { get; set; }

            public int HouseNumber { get; set; }

            public Address(string streetName, int houseNumber)
            {
                this.StreetName = streetName ?? throw new ArgumentNullException(nameof(StreetName));
                this.HouseNumber = houseNumber;
            }

            public override string? ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
            }

            public Address DeepCopy()
            {
                return new Address(StreetName, HouseNumber);
            }

            public Address(Address address)
            {
                StreetName = address.StreetName;
                HouseNumber = address.HouseNumber;
            }
        }
        public static void Run()
        {
            var john = new Person(new[] { "John", "Smith" }, new Address("London Road", 123));

            var jane = john.DeepCopy();
            jane.Address.HouseNumber = 321;
            Console.WriteLine(john.ToString());
            Console.WriteLine(jane.ToString());
        }
    }
}
