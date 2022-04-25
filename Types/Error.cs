namespace WargamingApi.Types
{
    public struct Error
    {
        public string field { get; set; }
        public string message { get; set; }
        public uint code { get; set; }
        public object value { get; set; }
    }
}