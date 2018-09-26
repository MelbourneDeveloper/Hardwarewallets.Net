using Hardwarewallets.Net.Model;
using NBitcoin;
using System;

namespace Hardwarewallets.Net
{
    public class NicolasFlavouredAddressPath : IAddressPath
    {
        KeyPath KeyPath { get; set; }

        //TODO: These numbers should be unhardended. 

        public uint Purpose => KeyPath.Indexes[0];

        public uint CoinType => KeyPath.Indexes[1];

        public uint Account => KeyPath.Indexes[2];

        public uint Change => KeyPath.Indexes[3];

        public uint AddressIndex => KeyPath.Indexes[4];

        public NicolasFlavouredAddressPath(KeyPath keyPath)
        {
            KeyPath = keyPath;
        }

        public uint[] ToUnhardenedArray()
        {
            throw new NotImplementedException();
        }

        public uint[] ToHardenedArray()
        {
            return new uint[5] { Purpose, CoinType, Account, Change, AddressIndex };
        }
    }
}
