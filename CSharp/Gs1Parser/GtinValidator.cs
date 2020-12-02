using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Gs1Parser
{
    public class GtinValidator
    {
        private readonly string ValidationRegex = "^(\\d{12,14}|\\d{8})$";

        private int ToInt(string numString)
        {
            return int.Parse(numString);
        }

        private static bool IsOdd(int num)
        {
            return (num % 2) == 1;
        }

        public bool Validate(string barcode)
        {
            if (!Regex.IsMatch(barcode, ValidationRegex))
            {
                return false;
            }

            int checksum = ToInt(barcode.Substring(barcode.Length - 1));
            int calcChecksum = this.CalculateChecksum(barcode);

            return (checksum == calcChecksum);
        }

        private int CalculateChecksum(string gtin)
        {
            var chunks = gtin.ToCharArray()
                .Select(n => ToInt(n.ToString()))
                .Reverse()
                .ToList();
            int checksum = 0;

            // Remove first chuck (checksum)
            chunks.RemoveAt(0);

            for (int i = 0; i < chunks.Count; i++)
            {
                checksum += IsOdd(i) ? chunks[i] : chunks[i] * 3;
            }

            // calc checksum
            checksum %= 10;
            checksum = (checksum == 0) ? 0 : (10 - checksum);

            return checksum;
        }
    }
}
