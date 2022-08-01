#nullable enable
using System.Collections.Generic;
using Newtonsoft.Json;
using WargamingApi.Types.Enums;

namespace WargamingApi.Types
{
    public class RequestParameters
    {
        public string? Search { get; set; }
        public string? AccessToken { get; set; }


        [JsonProperty("account_id")] public IEnumerable<long>? AccountId { get; set; }

        public IEnumerable<string>? Fields { get; set; }

        public IEnumerable<string>? Game { get; set; }


        public Language? Language { get; set; }


        public Type? Type { get; set; }

        public byte? Limit { get; set; }
    }
}