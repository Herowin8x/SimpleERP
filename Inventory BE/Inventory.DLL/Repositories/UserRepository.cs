using Microsoft.EntityFrameworkCore;
using Inventory.DLL.Entities;

namespace Inventory.DLL.Repositories
{
    public class UserRepository
    {
        private readonly InventoryDBContext _dbContext;

        public UserRepository(InventoryDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<UserEntity?> Read(string username, string password)
        {
            var userEntity = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);
            if (userEntity != null && BCrypt.Net.BCrypt.Verify(password, userEntity.Password))
               return userEntity; 

            return null;
        }
    }
}
