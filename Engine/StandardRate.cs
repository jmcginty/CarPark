namespace Engine
{
    public class StandardRate: BaseRate
    {
        public override string Name => "Standard";
        public override RateType Type => RateType.Hourly;
    }
}