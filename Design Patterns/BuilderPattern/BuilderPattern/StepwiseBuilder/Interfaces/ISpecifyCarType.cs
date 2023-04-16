namespace BuilderPattern.StepwiseBuilder.Interfaces
{
    public interface ISpecifyCarType
    {
        ISpecifyWheelSize OfType(CarType type);
    }
}
