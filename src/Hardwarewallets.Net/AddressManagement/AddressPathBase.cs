using Hardwarewallets.Net.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hardwarewallets.Net.AddressManagement
{
    public abstract class AddressPathBase : IAddressPath
    {
        #region Public Properties
        public List<IAddressPathElement> AddressPathElements { get; private set; } = new List<IAddressPathElement>();
        #endregion

        #region Private Static Methods
        private static AddressPathElement ParseElement(string elementString)
        {
            var harden = elementString.EndsWith("'");

            if (!uint.TryParse(elementString.Replace("'", string.Empty), out var unhardenedNumber))
            {
                throw new Exception($"The value {elementString} is not a valid path element");
            }

            return new AddressPathElement { Harden = harden, UnhardenedValue = unhardenedNumber };
        }
        #endregion

        #region Public Methods
        public uint[] ToArray() => AddressPathElements.Select(ape => ape.Harden ? AddressUtilities.HardenNumber(ape.UnhardenedValue) : ape.UnhardenedValue).ToArray();
        #endregion

        #region Public Static Methods
        public static T Parse<T>(string path) where T : AddressPathBase, new() =>
            new T
            {
                AddressPathElements = path.Split('/')
               .Where(t => string.Compare("m", t, StringComparison.OrdinalIgnoreCase) != 0)
               .Select(ParseElement)
               .Cast<IAddressPathElement>()
               .ToList()
            };
        #endregion
    }
}
