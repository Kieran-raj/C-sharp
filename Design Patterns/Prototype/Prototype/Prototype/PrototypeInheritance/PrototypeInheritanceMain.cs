namespace Prototype.PrototypeInheritance
{
    public class Address : IDeepCopyable<Address>
    {
        public string StreetName { get; set; }
        public int HouseNumber { get; set; }

        public Address()
        {
        }

        public Address(string streetName, int houseNumber)
        {
            StreetName = streetName;
            HouseNumber = houseNumber;
        }
        public override string? ToString()
        {
            return $"{nameof(StreetName)}: {StreetName}, {nameof(HouseNumber)}: {HouseNumber}";
        }

        public void CopyTo(Address target)
        {
            target.StreetName = StreetName;
            target.HouseNumber = HouseNumber;
        }
    }

    public class Person : IDeepCopyable<Person>
    {
        public string[] Names { get; set; }
        public Address Address { get; set; }

        public Person()
        {
        }

        public Person(string[] names, Address address)
        {
            this.Address = address ?? throw new ArgumentNullException(nameof(address));
            this.Names = names ?? throw new ArgumentNullException(nameof(names));
        }

        public override string? ToString()
        {
            return $"{nameof(Names)}: {string.Join(" ", Names)}, {nameof(Address)}: {Address}";
        }

        public void CopyTo(Person target)
        {
            target.Names = (string[])Names.Clone();
            target.Address = Address.DeepCopy();
        }
    }

    public class Employee : Person, IDeepCopyable<Employee>
    {
        public int Salary { get; set; }

        public Employee()
        {
        }

        public Employee(string[] names, Address address, int salary) : base(names, address)
        {
            this.Salary = salary;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Salary)}: {Salary}";
        }

        public void CopyTo(Employee target)
        {
            base.CopyTo(target);
            target.Salary = Salary;
            
        }
    }

    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item)
            where T : new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person)
            where T : Person, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }

    public interface IDeepCopyable<T>
     where T : new()
    {
        void CopyTo(T target);

        public T DeepCopy()
        {
            T t = new T();
            CopyTo(t);
            return t;
        }
    }

    public class PrototypeInheritanceMain
    {

        public static void Run()
        {
            var john = new Employee();
            john.Names = new[] { "John", "Doe" };
            john.Address = new Address
            {
                HouseNumber = 123,
                StreetName = "London Road"
            };
            john.Salary = 123000;
            var copy = john.DeepCopy();
            var p = john.DeepCopy<Person>(); // This will clone the parts relevant to person

            copy.Names[1] = "Smith";
            copy.Address.HouseNumber = 321;
            copy.Salary = 321000;

            Console.WriteLine(john);
            Console.WriteLine(copy);
        }
    }
}
