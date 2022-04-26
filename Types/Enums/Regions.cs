using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WargamingApi.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Regions : byte
    {
        Ru,
        Eu,
        Na,
        Asia
    }
}