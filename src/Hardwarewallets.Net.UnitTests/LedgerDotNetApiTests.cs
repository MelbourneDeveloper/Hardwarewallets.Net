using LedgerWallet;
using NBitcoin;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public class LedgerDotNetApiTests : UnitTestBase
    {
        [Fact]
        public override async Task GetBitcoinAddress()
        {
            await Initialize();

            //TODO: These should be hardended and they should be unhardened at the other end
            var address = await HardwarewalletManager.GetAddressAsync(new NicolasFlavouredAddressPath(new KeyPath("49/0/0/0/0")), true);
        }

        public override async Task Initialize()
        {
            var ledgerClient = (await LedgerClient.GetHIDLedgersAsync()).First();
            HardwarewalletManager = new LedgerDotNetApiWrapper(ledgerClient);
        }
    }
}
