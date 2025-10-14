using System.ComponentModel.DataAnnotations.Schema;

namespace Inventory.DLL.Entities
{
    [Table("User")]
    public class UserEntity : BaseEntity
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string Role { get; set; }
    }
}