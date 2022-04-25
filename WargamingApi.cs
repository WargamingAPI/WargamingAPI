using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WargamingApi;

public class WargamingApi
{
    internal static HttpClient Client;
    internal static readonly TimeSpan RateLimit = TimeSpan.FromMilliseconds(111.1f);
    internal static DateTime LastRequest = DateTime.UtcNow;

    public static readonly JsonSerializerSettings SerializationOptions =
        new()
        {
            MissingMemberHandling = MissingMemberHandling.Ignore,
            NullValueHandling = NullValueHandling.Ignore,
            DefaultValueHandling = DefaultValueHandling.Ignore
        };

    public WargamingApi(HttpClient client)
    {
        Client = client;
        Client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json")
        );
    }

    internal static async Task RateLimiter(TimeSpan? timeout = null)
    {
        timeout ??= RateLimit;

        while (true)
        {
            if (DateTime.UtcNow - LastRequest > timeout)
                break;
            await Task.Delay((TimeSpan) timeout - (DateTime.UtcNow - LastRequest));
        }

        LastRequest = DateTime.UtcNow;
    }

    public static async Task<T> GetRequest<T>(Uri uri)
    {
        await RateLimiter();

        var resp = await Client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
        resp.EnsureSuccessStatusCode();

        return JsonConvert.DeserializeObject<T>(
            await resp.Content.ReadAsStringAsync(),
            SerializationOptions
        );
    }
}