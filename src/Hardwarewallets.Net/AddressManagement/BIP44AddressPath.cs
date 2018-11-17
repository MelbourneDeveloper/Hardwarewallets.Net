using Hardwarewallets.Net.Model;

namespace Hardwarewallets.Net.AddressManagement
{
    public class BIP44AddressPath : AddressPathBase, IBIP44AddressPath
    {
        public uint Purpose => AddressPathElements[0].UnhardenedValue;

        public uint CoinType => AddressPathElements[1].UnhardenedValue;

        public uint Account => AddressPathElements[2].UnhardenedValue;

        public uint Change => AddressPathElements[3].UnhardenedValue;

        public uint AddressIndex => AddressPathElements[4].UnhardenedValue;

        public BIP44AddressPath()
        {

        }

        public BIP44AddressPath(bool isSegwit, uint coinType, uint account, bool isChange, uint addressIndex)
        {
            AddressPathElements.Add(new AddressPathElement { UnhardenedValue = isSegwit ? (uint)49 : 44, Harden = true });
            AddressPathElements.Add(new AddressPathElement { UnhardenedValue = coinType, Harden = true });
            AddressPathElements.Add(new AddressPathElement { UnhardenedValue = account, Harden = true });
            AddressPathElements.Add(new AddressPathElement { UnhardenedValue = isChange ? 1 : (uint)0, Harden = false });
            AddressPathElements.Add(new AddressPathElement { UnhardenedValue = addressIndex, Harden = false });
        }

        public uint[] ToUnhardenedArray()
        {
            return new uint[5] { Purpose, CoinType, Account, Change, AddressIndex };
        }
    }
}
