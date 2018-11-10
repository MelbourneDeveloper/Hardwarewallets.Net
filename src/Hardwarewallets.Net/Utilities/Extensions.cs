using System;
using System.Collections.Generic;
using System.Text;

namespace Hardwarewallets.Net.Utilities
{
    public static class Extensions
    {
        public static byte[] ToHexBytes(this string ethString)
        {
            var numberOfCharacters = ethString.Length / 2;
            var returnValue = new byte[numberOfCharacters];

            for (var i = 0; i < numberOfCharacters; i++)
            {
                var x = i * 2;
                var firstHexCharacter = ethString[x];
                var secondHexCharacter = ethString[x + 1];

                var hexStringBuilder = new StringBuilder();
                hexStringBuilder.Append(firstHexCharacter);
                hexStringBuilder.Append(secondHexCharacter);

                var hexString = hexStringBuilder.ToString();

                returnValue[i] = byte.Parse(hexString, System.Globalization.NumberStyles.HexNumber);
            }

            return returnValue;
        }
    }
}
