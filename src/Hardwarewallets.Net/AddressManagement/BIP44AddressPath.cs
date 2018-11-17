using Hardwarewallets.Net.Model;
using System;

namespace Hardwarewallets.Net.AddressManagement
{
    public class BIP44AddressPath : AddressPathBase, IBIP44AddressPath
    {
        public uint Purpose => IsValid ? AddressPathElements[0].UnhardenedValue : 0;

        public uint CoinType => IsValid ? AddressPathElements[1].UnhardenedValue : 0;

        public uint Account => IsValid ? AddressPathElements[2].UnhardenedValue : 0;

        public uint Change => IsValid ? AddressPathElements[3].UnhardenedValue : 0;

        public uint AddressIndex => IsValid ? AddressPathElements[4].UnhardenedValue : 0;

        public BIP44AddressPath()
        {
        }

        private bool IsValid => AddressPathElements.Count == 5 ? true : throw new Exception($"The address path is not a valid BIP44 Address Path. 5 Elements are required but {AddressPathElements.Count} were found.");

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
