using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Engine
{
    public abstract class BaseRate
    {
        public abstract string Name { get; }
        [JsonConverter(typeof(StringEnumConverter))]
        public abstract RateType Type { get; }
        public decimal TotalPrice { get; set; }
    }
}