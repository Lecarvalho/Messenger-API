using System.Collections.Generic;
using System.Threading.Tasks;
using MessagerApi.Business.Models;
using MessagerApi.Services.Configuration;
using MessagerApi.Services.Providers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MessagerApi.Services.Dispatchers
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
