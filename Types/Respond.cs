#nullable enable
namespace WargamingApi.Types
{
    public class Respond
    {
        public string Status { get; set; } = "";
        public Error? Error { get; set; }
        public Meta? Meta { get; set; }
    }

    public class Respond<T, TT> : Respond
    {
        public new T Meta { get; set; } = default!;
        public TT Data { get; set; } = default!;
    }
}