using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TotpAPI.DataTransferObjects
{
    public class TotpInputDTO
    {
        public int Step { get; set; }

        public string Key { get; set; }

        public int PasswordLength { get; set; }

        public string UserId { get; set; }

        public DateTime TimeStamp { get; set; }

    }
}
