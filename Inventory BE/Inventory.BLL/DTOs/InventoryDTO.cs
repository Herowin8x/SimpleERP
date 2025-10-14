namespace Inventory.BLL.DTOs
{
    public class InventoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Suppliers { get; set; }
        public string? Manufacturers { get; set; }
    }
}
