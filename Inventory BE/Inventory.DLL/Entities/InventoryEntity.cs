using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DLL.Entities
{
    [Table("Inventory")]
    public class InventoryEntity : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Color { get; set; }
        public string? Suppliers { get; set; }
        public string? Manufacturers { get; set; }
    }
}
