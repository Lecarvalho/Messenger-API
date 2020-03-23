using System.Collections.Generic;
using System.Threading.Tasks;
using MessengerApi.Business.Models;
using MessengerApi.Services.Configuration;
using MessengerApi.Services.Providers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MessengerApi.Services.Dispatchers
{
    public class SlackDispatcher : DispatcherBase
    {
        private NetworkProvider _networkProvider;
        private SlackConfig _config;

        public SlackDispatcher(SlackConfig config)
        {
            _networkProvider = new NetworkProvider();
            _config = config;
        }

        public override async Task Send(MessageModel message, string appName)
        {
            var jsonString = PrepareJson(message);
            await _networkProvider.RequestPost(_config.Webhook, jsonString);
        }

        protected string PrepareJson(MessageModel message)
        {
            return new SlackStruct(message.Content, message.User.Name, message.User.Token).ToJson();
        }
    }
}
