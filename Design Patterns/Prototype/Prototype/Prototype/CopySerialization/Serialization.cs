using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Prototype.CopySerialiation
{
    public static class ExtensionMethods
    {
        public static T DeepCopy<T>(this T self)
        {
            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, self);

            stream.Seek(0, SeekOrigin.Begin);
            object copy = formatter.Deserialize(stream);
            stream.Close();
            return (T)copy;
        }

        public static T DeepCopyXml<T>(this T self)
        {
            using (var ms = new MemoryStream())
            {
                var s = new XmlSerializer(typeof(T);
                s.Serialize(ms, self);
                ms.Position = 0;
                return (T) s.Deserialize(ms);
            }
        }
    }

    public class Serialization
    {
        [Serializable]
        public class Person
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

            public Person(Person other)
            {
                Names = other.Names;
                Address = new Address(other.Address);
            }
        }

        [Serializable]
        public class Address
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
            jane.Names[0] = "Jane";
            jane.Address.HouseNumber = 321;
            Console.WriteLine(john.ToString());
            Console.WriteLine(jane.ToString());
        }
    }
}
