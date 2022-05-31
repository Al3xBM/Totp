using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotpAPI.Services.Interfaces
{
    public interface ITotpService
    {
        public string ComputeTotp(string userId, string key, int step, int passLength);
    }
}
