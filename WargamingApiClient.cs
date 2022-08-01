#nullable enable
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ComposableAsync;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RateLimiter;

namespace WargamingApi
{
    public sealed class WargamingApiClient
    {
        private static HttpClient m_client = null!;
        private static readonly DelegatingHandler m_handler = TimeLimiter.GetFromMaxCountByInterval(10, TimeSpan.FromSeconds(1)).AsDelegatingHandler();

        public readonly string ApplicationId;

        public static readonly JsonSerializerSettings SerializationOptions =
            new JsonSerializerSettings
            {
                MissingMemberHandling = MissingMemberHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new LowercaseContractResolver()
            };

        public WargamingApiClient(string applicationId)
        {
            m_client = new HttpClient(m_handler);
            m_client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
            ApplicationId = applicationId;
        }

        public static Task<T> GetRequest<T>(Uri uri)
        {
            return Task.Run(
                async () =>
                {
                    var resp = await m_client.SendAsync(new HttpRequestMessage(HttpMethod.Get, uri));
                    resp.EnsureSuccessStatusCode();

                    return JsonConvert.DeserializeObject<T>(
                        await resp.Content.ReadAsStringAsync(),
                        SerializationOptions
                    )!;
                }
            );
        }

        private class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName) => propertyName.ToLower();
        }
    }
}