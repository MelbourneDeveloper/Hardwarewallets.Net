using Hardwarewallets.Net.Model;

namespace Hardwarewallets.Net.AddressManagement
{
    public class AddressPathElement : IAddressPathElement
    {
        public uint Value { get; set; }

        public bool Harden { get; set; }
    }
}
