using Hardwarewallets.Net.Base;
using NBitcoin;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public abstract class UnitTestBase
    {
        public static IHardwarewalletManager HardwarewalletManager { get; protected set; }
        public abstract Task Initialize();

        [Fact]
        public async Task GetBitcoinAddress()
        {
            await Initialize();
            var address = await HardwarewalletManager.GetAddressAsync(new NicolasFlavouredAddressPath(new KeyPath("49/0/0/0/0")), true);
        }
    }
}
