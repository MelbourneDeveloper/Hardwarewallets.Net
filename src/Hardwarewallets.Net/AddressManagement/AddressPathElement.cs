using Hardwarewallets.Net.Model;

namespace Hardwarewallets.Net.AddressManagement
{
    public class AddressPathElement : IAddressPathElement
    {
        public uint UnhardenedValue { get; set; }

        public bool Harden { get; set; }
    }
}
