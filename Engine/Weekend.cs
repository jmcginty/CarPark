namespace Engine
{
    public class WeekendRate: BaseRate
    {
        public override string Name => "Weekend";
        public override RateType Type => RateType.Flat;
    }
}