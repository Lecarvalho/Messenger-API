using System.Collections.Generic;
using System.Threading.Tasks;
using MessengerApi.Business.Models;
using MessengerApi.Services.Configuration;
using MessengerApi.Services.Dispatchers;
using Microsoft.Extensions.Options;

namespace MessengerApi.Services
{
    public class DispatcherService
    {
        List<DispatcherBase> _dispatchers;
        string appName;
        public DispatcherService(IOptions<DispatchOptions> dispatcherConfigOptions, IOptions<AppConfig> appConfigOptions)
        {
            appName = appConfigOptions.Value.AppName;

            _dispatchers = new List<DispatcherBase>();
            var dispatcherConfig = dispatcherConfigOptions.Value;

            if (dispatcherConfig.Slack != null)
                _dispatchers.Add(new SlackDispatcher(dispatcherConfig.Slack));

            if (dispatcherConfig.Email != null)
                _dispatchers.Add(new EmailDispatcher(dispatcherConfig.Email));

        }


        public async Task SendMessage(MessageModel message)
        {
            foreach (var dispatcher in _dispatchers)
            {
                await dispatcher.Send(message, appName);
            }
        }
    }
}