using Hardwarewallets.Net.Base.Ethereum;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public class DummyUnitTests : UnitTestBase
    {
        public async override Task Initialize()
        {
            HardwarewalletManager = new DummyWalletManager();
        }

        [Fact]
        public async Task GetBitcoinPublicKey()
        {
            var publicKey = await HardwarewalletManager.GetPublicKeyAsync(new AddressPath(true, 0, 0, false, 0), true);
            Assert.Equal("02a1633cafcc01ebfb6d78e39f687a1f0995c62fc95f51ead10a02ee0be551b5dc", publicKey);
        }

        [Fact]
        public async Task GetEthereumAddress()
        {
            var address = await HardwarewalletManager.GetAddressAsync(new AddressPath(true, 60, 0, false, 0), true);
            Assert.Equal("0x3f2dD9850509367b57C900F7e1C5f4F0bfF1014B", address);
        }

        [Fact]
        public async Task GetEthereumPublicKey()
        {
            var publicKey = await HardwarewalletManager.GetPublicKeyAsync(new AddressPath(true, 60, 0, false, 0), true);
            Assert.Equal("0x3f2dD9850509367b57C900F7e1C5f4F0bfF1014Bf4F0bfF1014B", publicKey);
        }

        [Fact]
        public async Task SignEthereumTransaction()
        {
            var signedTransaction = await HardwarewalletManager.SignTransaction<IEthereumTransaction, ISignedEthereumTransaction>(new DummyEthereumTransaction());
            Assert.Equal(32, signedTransaction.SignatureR.Length);
            Assert.Equal(32, signedTransaction.SignatureS.Length);
        }

    }
}
