namespace NET_9_Business_App_MVC.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public string? InventoryName { get; set; }
        public string? InventoryDescription { get; set; }
        public List<string>? InventoryMediaLinks { get; set; }
        public double? InventoryPrice { get; set; }
        public int? InventoryQuantity { get; set; }
        public string? InventoryCategory { get; set; }
        public string? InventoryDepartment { get; set; }
        public string? InventorySupplier { get; set; }
        public string? InventoryLocation { get; set; }
        public string? InventoryStatus { get; set; }
        public string? InventoryManufacturer { get; set; }      

    }
   
   /* class Program
    {
        static void Main(string[] args)
        {
            // Example usage of the Inventory class
            Inventory inventoryItem = new Inventory
            {
                InventoryId = 1,
                InventoryName = "Guitar",
                InventoryDescription = "Electric guitar",
                InventoryPrice = 499.99,
                InventoryQuantity = 10,
                InventoryCategory = "Instruments",
                InventoryDepartment = "Music",
                InventorySupplier = "Guitar Supplier",
                InventoryLocation = "Warehouse A",
                InventoryStatus = "Available",
                InventoryManufacturer = "Guitar Co."
            };
            Console.WriteLine($"Inventory Item: {inventoryItem.InventoryName}, Price: {inventoryItem.InventoryPrice}");
        }
    }*/
}