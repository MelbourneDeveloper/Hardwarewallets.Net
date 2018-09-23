using Hardwarewallets.Net.Base;

namespace Hardwarewallets.Net
{
    public class AddressPath : IAddressPath
    {
        private const uint HardeningConstant = 0x80000000;

        public uint Purpose { get; }

        public uint CoinType { get; }

        public uint Account { get; }

        public uint Change { get; }

        public uint AddressIndex { get; }

        public AddressPath(bool isSegwit, uint cointType, uint account, bool isChange, uint addressIndex)
        {
            Purpose = isSegwit ? (uint)49 : 44;
            CoinType = cointType;
            Account = account;
            Change = isChange ? 1 : (uint)0;
            AddressIndex = addressIndex;
        }

        public uint[] ToUnhardenedArray()
        {
            return new uint[5] { Purpose, CoinType, Account, Change, AddressIndex };
        }

        public uint[] ToHardenedArray()
        {
            return new uint[5] { (Purpose | HardeningConstant) >> 0, (CoinType | HardeningConstant) >> 0, (Account | HardeningConstant) >> 0, Change, AddressIndex };
        }
    }
}
