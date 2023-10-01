namespace Factories.Exercise
{
    public class PersonFactory
    {
        private Dictionary<string, Person> people = new Dictionary<string, Person>();
        private int countStart = 0;

        public Person CreatePerson(string name)
        {
            var newPerson = new Person();
            newPerson.Name = name;
            newPerson.Id = countStart;

            people.Add(countStart.ToString(), newPerson);
            countStart++;

            return newPerson;
        }
    }
}
