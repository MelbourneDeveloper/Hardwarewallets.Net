using LedgerWallet;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public class LedgerDotNetApiTests
    {
        private static LedgerClient _LedgerClient;

        [Fact]
        public async Task GetBitcoinAddress()
        {
            _LedgerClient = (await LedgerClient.GetHIDLedgersAsync()).First();
            var ledgerDotNetApiWrapper = new LedgerDotNetApiWrapper(_LedgerClient);
            var address = await ledgerDotNetApiWrapper.GetAddressAsync(new AddressPath(true, 0, 0, false, 0), true);
        }
    }
}
