
using NServiceBus.Logging;
using Sheesh.Operations.Inventory.ServiceContracts;

namespace Sheesh.Operations.Inventory.Application;

public class Program
{
    private static ILog _logger = LogManager.GetLogger<Program>();

    public static async Task Main()
    {
        var endpointConfiguration = new EndpointConfiguration("Sheesh.Operations.Inventory");
        endpointConfiguration.UseSerialization<SystemJsonSerializer>();

        var transport = endpointConfiguration.UseTransport<LearningTransport>();

        var endpointInstance = await Endpoint.Start(endpointConfiguration);

        await RunLoop(endpointInstance);

        await endpointInstance.Stop();
    }

    private static async Task RunLoop(IEndpointInstance endpointInstance)
    {

        while (true)
        {
            _logger.Info("Press 'P' to place an order or 'Q' to quit.");

            var key = Console.ReadKey();

            switch(key.Key)
            {
                case ConsoleKey.P:
                    var command = new DoSomething()
                    {
                        SomeProperty = "Hello world"
                    };

                    _logger.Info($"Sending DoSomething command");
                    await endpointInstance.SendLocal(command);
                    break;
                case ConsoleKey.Q:
                    return;

                default:
                    break;
            }
        }
    }
}