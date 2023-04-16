namespace BuilderPattern.FunctionalBuilder
{
    public abstract class FunctionalBuilder<TSubject, T>
        where T : FunctionalBuilder<TSubject, T>
        where TSubject : new()
    {
        private readonly List<Func<TSubject, TSubject>> actions = new List<Func<TSubject, TSubject>>();

        public TSubject Build()
        {
            return actions.Aggregate(new TSubject(), (p, f) => f(p));
        }

        public T Do(Action<TSubject> action)
        {
            return AddAction(action);
        }

        private T AddAction(Action<TSubject> action)
        {
            actions.Add(p => { action(p); return p; });
            return (T)this;
        }
    }
}
