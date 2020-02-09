using System.Collections.Generic;
using System.Threading.Tasks;
using MessagerApi.Business.Models;
using MessagerApi.Services.Configuration;
using MessagerApi.Services.Dispatchers;
using Microsoft.Extensions.Options;

namespace MessagerApi.Services
{
    public class DispatcherService
    {
        List<DispatcherBase> _dispatchers;
        public DispatcherService(IOptions<DispatcherConfig> dispatcherConfigOptions)
        {   
            _dispatchers = new List<DispatcherBase>();
            var dispatcherConfig = dispatcherConfigOptions.Value;
            if (dispatcherConfig.Slack != null)
                _dispatchers.Add(new SlackDispatcher(dispatcherConfig.Slack));
            
        }


        public async Task SendMessage(MessageModel message)
        {
            foreach (var dispatcher in _dispatchers)
            {
                await dispatcher.Send(message);
            }
        }
    }
}