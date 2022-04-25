#nullable enable
namespace WargamingApi.Types
{
    public class Respond
    {
        public string status { get; set; } = "";
        public Error? error { get; set; }
        public Meta? meta { get; set; }
    }

    public class Respond<T, TT> : Respond
    {
        public new T meta { get; set; }
        public TT data { get; set; }
    }
}