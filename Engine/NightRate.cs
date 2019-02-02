namespace Engine
{
    public class NightRate: BaseRate
    {
        public override string Name => "Night";
        public override RateType Type => RateType.Flat;
    }
}