namespace Sheesh.Operations.Inventory.Domain.Entities
{
    public class Item
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public float Price { get; set; }

        public string Description { get; set; }

        public int Stock { get; set; }
    }
}
