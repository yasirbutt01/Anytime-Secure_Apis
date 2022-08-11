using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace AnytimeSecure.Common
{
    public class SystemGlobal
    {
        public static Guid GetId()
        {
            return Guid.NewGuid();
        }

        public static int Get6digitOTP()
        {
            return new Random().Next(100000, 999999);
        }

        public decimal DiffrenceInMunites(DateTime startTime, DateTime endTime)
        {
            return Convert.ToDecimal(endTime.Subtract(startTime).TotalMinutes);
        }

        public static long GetUniqueCode()
        {
            return Convert.ToInt64(DateTime.UtcNow.ToString("ddMMyyHHmmssfff" + new Random().Next(111, 999)));
        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GetRandomColor()
        {
            var colors = new List<string> { "#A8DB82", "#A49FD3", "#FF5733", "#D6AD00", "#2600A5" };
            int index = random.Next(colors.Count);
            var name = colors[index];
            return name;
        }

        public static DateTime ConvertToLocal(DateTime date, string gmt)
        {
            if (gmt.Contains("UTC") || gmt.Contains("utc"))
            {
                gmt = gmt.Replace("UTC", "");
            }
            return date
                .AddHours(Convert.ToInt32(gmt[0] + gmt.Split(':')[0].Substring(1)))
                .AddMinutes(Convert.ToInt32(gmt[0] + gmt.Split(':')[1]));
        }
    }
}
