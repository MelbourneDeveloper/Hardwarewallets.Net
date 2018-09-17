using Hardwarewallets.Net.Base;
using NBitcoin;

namespace Hardwarewallets.Net
{
    public class NicolasFlavouredAddressPath : IAddressPath
    {
        KeyPath KeyPath { get; set; }

        public uint Purpose => KeyPath.Indexes[0];

        public uint CoinType => KeyPath.Indexes[1];

        public uint Account => KeyPath.Indexes[2];

        public uint Change => KeyPath.Indexes[3];

        public uint AddressIndex => KeyPath.Indexes[4];

        public NicolasFlavouredAddressPath(KeyPath keyPath)
        {
            KeyPath = keyPath;
        }
    }
}
