#nullable enable
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WargamingApi.Types
{
    public class RequestParameters
    {
        public string? Search { get; set; }
        public string? AccessToken { get; set; }


        [JsonProperty("account_id")]
        [System.Text.Json.Serialization.JsonConverter(typeof(ArrayConverter))]
        public IEnumerable<long>? AccountId { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(ArrayConverter))]
        public IEnumerable<string>? Fields { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(ArrayConverter))]
        public IEnumerable<string>? Game { get; set; }


        [System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter))]
        public Language? Language { get; set; }

        [System.Text.Json.Serialization.JsonConverter(typeof(StringEnumConverter))]
        public Type? Type { get; set; }

        public byte? Limit { get; set; }
    }
}