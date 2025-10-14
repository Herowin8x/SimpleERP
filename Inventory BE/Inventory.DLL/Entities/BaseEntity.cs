namespace Inventory.DLL.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate {  get; set; }
        public string? CreatedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
