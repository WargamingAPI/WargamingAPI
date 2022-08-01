using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WargamingApi.Types.Enums;

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
                var dict = JsonSerializer.Deserialize<Dictionary<string, object>>(value)!;
                var sb = new StringBuilder(Parameters);
                foreach (var (key, val) in dict)
                {
                    if (val == null) continue;
                    var strVal = val.ToString();
                    try
                    {
                        var arr = ((JsonElement) val).EnumerateArray();
                        strVal = string.Join(',', arr);
                    }
                    catch
                    {
                        // ignore
                    }

                    if (!string.IsNullOrEmpty(strVal) && !string.IsNullOrWhiteSpace(strVal))
                        sb.Append($"&{key}={strVal}".ToLower());
                }

                Parameters = sb.ToString();
            }
        }
    }
}