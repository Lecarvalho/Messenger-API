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
        SlackDispatcherConfig _dispatcherConfig;
        NetworkProvider _networkProvider;
        public SlackDispatcher(SlackDispatcherConfig dispatcherConfig)
        {
            _dispatcherConfig = dispatcherConfig;
            _networkProvider = new NetworkProvider();
        }

        public override async Task Send(MessageModel message)
        {
            var jsonString = PrepareJson(message);
            await _networkProvider.RequestPost(_dispatcherConfig.Webhook, jsonString);
        }

        protected override string PrepareJson(MessageModel message)
        {
            return new SlackStruct(message.Content, message.User?.Name).ToJson();
        }
    }
}
