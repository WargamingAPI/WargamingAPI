using System.Collections.Generic;
using System.Text.Json;

namespace WargamingApi.Types
{
    public class RequestArguments
    {
        public Regions Region;

        public string Parameters { get; set; } = "";

        protected string RequestParameters
        {
            set
            {
                var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(value);
                foreach (var (key, val) in dict)
                {
                    if (val == null) continue;
                    var strVal = val.ToString();
                    if (!string.IsNullOrEmpty(strVal) && !string.IsNullOrWhiteSpace(strVal))
                        Parameters += $"&{key}={strVal}";
                }
            }
        }
    }
}