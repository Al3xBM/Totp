using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using TotpAPI.Helpers;
using TotpAPI.Services.Interfaces;

namespace TotpAPI.Services
{
    public class TotpService : ITotpService
    {
        public long CurrentTimeInSeconds
        {
            get
            {
                return (long)Math.Floor((DateTime.Now.ToUniversalTime() - DateTime.UnixEpoch).TotalSeconds);
            }
        }

        // how should userId be used?
        public string ComputeTotp(string userId, string key, int step, int passLength)
        {
            byte[] keyBytes = ConverterHelper.ConvertToBytes(key);
            long timeStamp = CurrentTimeInSeconds;
            byte[] bigEndianBytes = BitConverter.GetBytes(timeStamp).Reverse().ToArray();
            HMACSHA1 hmac = new HMACSHA1();
            hmac.Key = keyBytes;
            byte[] computedHash = hmac.ComputeHash(bigEndianBytes);
            int offset = computedHash.Last() & 0x0F;

            var otp = (computedHash[offset] & 0x7f) << 24
               | (computedHash[offset + 1] & 0xff) << 16
               | (computedHash[offset + 2] & 0xff) << 8
               | (computedHash[offset + 3] & 0xff);

            var totp = ((int)otp % Math.Pow(10, passLength)).ToString(new string('0', passLength));

            return totp;
        }
    }
}
