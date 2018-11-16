using Hardwarewallets.Net.Model;
using System.Collections.ObjectModel;
using System.Linq;

namespace Hardwarewallets.Net.AddressManagement
{
    public class AddressPathBase : IAddressPath
    {
        #region Public Properties
        public Collection<IAddressPathElement> AddressPathElements { get; } = new Collection<IAddressPathElement>();
        #endregion

        #region Public Methods
        public uint[] ToArray() =>  AddressPathElements.Select(ape => ape.Harden ? AddressUtilities.HardenNumber(ape.UnhardenedValue) : ape.UnhardenedValue).ToArray();     
        #endregion
    }
}
