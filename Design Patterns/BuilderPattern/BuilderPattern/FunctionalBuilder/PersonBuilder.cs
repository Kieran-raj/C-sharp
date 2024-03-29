﻿namespace BuilderPattern.FunctionalBuilder
{
    public sealed class PersonBuilder : FunctionalBuilder<Person, PersonBuilder>
    {
        public PersonBuilder Called(string name)
        {
            return Do(p => p.Name = name);
        }
    }
}
