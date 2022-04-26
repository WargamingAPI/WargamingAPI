#nullable enable
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WargamingApi.Types
{
    public class RequestParameters
    {
        public string? search { get; set; }
        public string? access_token { get; set; }


        [JsonConverter(typeof(ArrayConverter))]
        public IEnumerable<long>? account_id { get; set; }

        [JsonConverter(typeof(ArrayConverter))]
        public IEnumerable<string>? fields { get; set; }

        [JsonConverter(typeof(ArrayConverter))]
        public IEnumerable<string>? game { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public Language? language { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public Types? type { get; set; }

        public byte? Limit { get; set; }
    }
}