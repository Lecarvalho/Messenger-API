using System.Threading.Tasks;
using MessengerApi.Business.Models;
using MessengerApi.Services.Configuration;
using Microsoft.Extensions.Options;

namespace MessengerApi.Services.Dispatchers
{
    public abstract class DispatcherBase
    {
        public abstract Task Send(MessageModel message);
    }
}