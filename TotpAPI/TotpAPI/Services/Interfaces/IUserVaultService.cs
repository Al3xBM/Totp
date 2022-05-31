using TotpAPI.Models;

namespace TotpAPI.Services.Interfaces
{
    public interface IUserVaultService
    {
        public UserVault Create(string userId);

        public UserVault GetByUserId(string userId);
    }
}
