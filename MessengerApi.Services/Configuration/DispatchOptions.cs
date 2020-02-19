namespace MessengerApi.Services.Configuration
{
    public class DispatchOptions
    {
        public SlackConfig Slack { get; set; }
        public EmailConfig Email { get; set; }
    }
}