namespace Engine
{
    public class EarlyBirdRate: BaseRate
    {
        public override string Name => "Early Bird";
        public override RateType Type => RateType.Flat;
    }
}