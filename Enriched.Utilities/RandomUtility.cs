using System;
using System.Security.Cryptography;

namespace Enriched.Utilities
{
    public static class RandomUtility
    {
        public static DateTime GetRandomDateTime(DateTime? startDateTime = null, DateTime? endDateTime = null)
        {
            var rnd = GetUniqueRandom();
            var rndYear = new Random().Next(-100, +100);
            var start = startDateTime ?? DateTime.Now.AddYears(rndYear);
            var end = endDateTime ?? DateTime.Now;
            var range = (end - start).Days;
            return start.AddDays(rnd.Next(range)).AddHours(rnd.Next(0, 24)).AddMinutes(rnd.Next(0, 60)).AddSeconds(rnd.Next(0, 60));
        }

        public static Random GetUniqueRandom()
        {
            return new Random(Guid.NewGuid().GetHashCode());
        }

        public static string GetRandomString(int length, string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890_")
        {
            if (length <= 0)
            {
                throw new ArgumentException($"'{nameof(length)}' cannot be zero or negative.");
            }

            using var crypto = new RNGCryptoServiceProvider();

            byte[] data = new byte[length];
            byte[] buffer = null;

            int maxRandom = byte.MaxValue - ((byte.MaxValue + 1) % chars.Length);

            crypto.GetBytes(data);

            char[] result = new char[length];

            for (int i = 0; i < length; i++)
            {
                byte value = data[i];

                while (value > maxRandom)
                {
                    if (buffer == null)
                    {
                        buffer = new byte[1];
                    }
                    crypto.GetBytes(buffer);
                    value = buffer[0];
                }
                result[i] = chars[value % chars.Length];
            }

            return new string(result);
        }
    }
}