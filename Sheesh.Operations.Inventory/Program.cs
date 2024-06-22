namespace Sheesh.Operations.Inventory;

public class Program
{
    public static async Task Main()
    {
        var endpointConfiguration = new EndpointConfiguration("Sheesh.Operations.Inventory");

        endpointConfiguration.UseSerialization<SystemJsonSerializer>();

        var transport = endpointConfiguration.UseTransport<LearningTransport>();

        var endpointInstance = await Endpoint.Start(endpointConfiguration);

        Console.WriteLine("Press enter to exit...");
        Console.ReadLine();

        await endpointInstance.Stop();
    }
}