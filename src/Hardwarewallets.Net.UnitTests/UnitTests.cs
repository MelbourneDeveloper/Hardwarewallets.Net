using Hardwarewallets.Net.Base;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public class UnitTests
    {
        private static IHardwarewalletManager HardwarewalletManager = new DummyWalletManager();

        [Fact]
        public async Task GetBitcoinAddress()
        {
            var address = await HardwarewalletManager.GetAddressAsync(new AddressPath(true, 0, 0, false, 0), true);
            Assert.Equal("1EdcJ3XAZ1jMHka8kwD6oyMkHuJC5qVu8p", address);
        }

        [Fact]
        public async Task GetBitcoinPublicKey()
        {
            var publicKey = await HardwarewalletManager.GetPublicKeyAsync(new AddressPath(true, 0, 0, false, 0), true);
            Assert.Equal("02a1633cafcc01ebfb6d78e39f687a1f0995c62fc95f51ead10a02ee0be551b5dc", publicKey);
        }

    }
}
