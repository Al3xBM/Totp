using System.Linq;
using TotpAPI.Helpers;
using TotpAPI.Models;
using TotpAPI.Models.Context;
using TotpAPI.Services.Interfaces;

namespace TotpAPI.Services
{
    public class UserVaultService : IUserVaultService
    {
        private readonly UserVaultContext _context;

        public UserVaultService(UserVaultContext context)
        {
            _context = context;
        }

        public UserVault Create(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return null;

            if (_context.UserVaults.Any(x => x.UserId == userId))
                return null;

            UserVault userVault = new UserVault() { 
                    UserId = userId, 
                    Secret = SecretGenerator.GetSecret(16) 
                };

            _context.UserVaults.Add(userVault);

            return userVault;
        }

        public UserVault GetByUserId(string userId) => _context.UserVaults.FirstOrDefault(x => x.UserId == userId);
        
    }
}
