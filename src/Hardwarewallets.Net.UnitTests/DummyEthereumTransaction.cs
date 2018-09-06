using Hardwarewallets.Net.Base;
using Hardwarewallets.Net.Base.Ethereum;

namespace Hardwarewallets.Net.UnitTests
{
    public class DummyEthereumTransaction : IEthereumTransaction
    {
        public uint ChainId => 0;

        public decimal GasPrice => (decimal)0.0000000035;

        public int GasLimit => 21000;

        public string Nonce => "0";

        public IAddressPath From => new AddressPath(false, 60, 0, false, 0);

        public decimal Value => (decimal)2.03016804;

        public string To => "0x3f2dD9850509367b57C900F7e1C5f4F0bfF1014B";
    }
}
