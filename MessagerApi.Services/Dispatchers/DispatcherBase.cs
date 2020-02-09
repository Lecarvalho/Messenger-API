using System.Threading.Tasks;
using MessagerApi.Business.Models;
using MessagerApi.Services.Configuration;
using Microsoft.Extensions.Options;

namespace MessagerApi.Services.Dispatchers
{
    public abstract class DispatcherBase
    {
        public abstract Task Send(MessageModel message);

        protected abstract string PrepareJson(MessageModel message);
    }
}