using Hardwarewallets.Net.Model;

namespace Hardwarewallets.Net.AddressManagement
{
    public class AddressPath : IAddressPath
    {
        public uint Purpose { get; }

        public uint CoinType { get; }

        public uint Account { get; }

        public uint Change { get; }

        public uint AddressIndex { get; }

        public AddressPath(bool isSegwit, uint coinType, uint account, bool isChange, uint addressIndex)
        {
            Purpose = isSegwit ? (uint)49 : 44;
            CoinType = coinType;
            Account = account;
            Change = isChange ? 1 : (uint)0;
            AddressIndex = addressIndex;
        }

        public uint[] ToUnhardenedArray()
        {
            return new uint[5] { Purpose, CoinType, Account, Change, AddressIndex };
        }

        public uint[] ToArray()
        {
            return new uint[5] { AddressUtilities.HardenNumber(Purpose), AddressUtilities.HardenNumber(CoinType), AddressUtilities.HardenNumber(Account), Change, AddressIndex };
        }
    }
}
