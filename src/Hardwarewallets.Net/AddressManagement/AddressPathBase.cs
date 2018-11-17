using Hardwarewallets.Net.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hardwarewallets.Net.AddressManagement
{
    public abstract class AddressPathBase : IAddressPath
    {
        #region Public Properties
        public List<IAddressPathElement> AddressPathElements { get; } = new List<IAddressPathElement>();
        #endregion

        #region Public Methods
        public uint[] ToArray() => AddressPathElements.Select(ape => ape.Harden ? AddressUtilities.HardenNumber(ape.UnhardenedValue) : ape.UnhardenedValue).ToArray();
        #endregion

        public static T Parse<T>(string path) where T : AddressPathBase, new()
        {
            var addressPathBase =  new T();

            path.Split('/').
               Where(t => string.Compare("m", t, true) != 0).
               Select(
               t => new AddressPathElement
               {
                   Harden = t.EndsWith("'"),
                   UnhardenedValue = ParseElement(t)
               }).ToList().ForEach(e => addressPathBase.AddressPathElements.Add(e));

            return addressPathBase;
        }

        private static uint ParseElement(string elementString)
        {
            if (!uint.TryParse(elementString.Replace("'", string.Empty), out var unhardenedNumber))
            {
                throw new Exception($"The value {elementString} is not a valid path element");
            }

            return unhardenedNumber;
        }
    }
}
