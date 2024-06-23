using Sheesh.Operations.Inventory.Domain;

namespace Sheesh.Operations.Inventory;
public class Program
{
    public static void Main(string[] args)
    {
        using (var context = new AppDbContext())
        {
            context.Database.EnsureCreated();
        }
    }
}