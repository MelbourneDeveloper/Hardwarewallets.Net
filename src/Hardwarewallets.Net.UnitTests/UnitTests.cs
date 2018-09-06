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
        }
    }
}
