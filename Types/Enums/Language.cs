using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WargamingApi.Types
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum Language : byte
    {
        En, // English
        Ru, // Русский     Default
        Pl, // Polski
        De, // Deutsch
        Fr, // French
        Es, // Spanish
        Tr, // Turkish
        Cs, // Czech
        Th, // Thai
        Vi, // Vietnamese
        Ko // Korean
    }
}