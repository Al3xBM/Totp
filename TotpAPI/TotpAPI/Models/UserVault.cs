using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotpAPI.Models
{
    public class UserVault
    {
        public int UserVaultId { get; set; }

        public string UserId { get; set; }

        public string Secret { get; set; }
    }
}
