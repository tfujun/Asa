using NServiceBus.Logging;
using Sheesh.Operations.Inventory.ServiceContracts;

namespace Sheesh.Operations.Inventory.Application
{
    public class DoSomethingHandler : IHandleMessages<DoSomething>
    {
        static ILog _logger = LogManager.GetLogger<DoSomethingHandler>();

        public Task Handle(DoSomething message, IMessageHandlerContext context)
        {
            _logger.Info($"Received DoSomething, SomeProperty = {message.SomeProperty}");

            return Task.CompletedTask;
        }
    }
}
