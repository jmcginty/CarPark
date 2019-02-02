namespace Engine
{
    public abstract class BaseRate
    {
        public abstract string Name { get; }
        public abstract RateType Type { get; }
        public decimal TotalPrice { get; set; }
    }
}