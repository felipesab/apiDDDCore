using Domain.Interfaces;
using Domain.Interfaces.Services;

namespace Domain.Services
{
    public class ServiceMessage : IServiceMessage
    {
        private readonly IMessage _IMessage;
        public ServiceMessage(IMessage IMessage) 
        {
            _IMessage= IMessage;
        }
    }
}
