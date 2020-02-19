namespace MessengerApi.Services.Configuration
{
    public class EmailConfig : ConfigBase
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Smtp { get; set; }
        public int Port { get; set; }
    }
}