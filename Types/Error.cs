namespace WargamingApi.Types
{
    public struct Error
    {
        public string Field { get; set; }
        public string Message { get; set; }
        public uint Code { get; set; }
        public object Value { get; set; }
    }
}