using System;
using System.Text;

namespace TotpAPI.Helpers
{
    public static class SecretGenerator
    {
        public static string GetSecret(int length)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();

            for(int i = 0; i < length; ++i)
            {
                double dbl = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * dbl));
                char letter = Convert.ToChar(shift);
                builder.Append(letter);
            }

            return builder.ToString().ToUpper();
        }
    }
}
