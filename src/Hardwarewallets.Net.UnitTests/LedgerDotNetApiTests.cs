using LedgerWallet;
using NBitcoin;
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
            var address = await ledgerDotNetApiWrapper.GetAddressAsync(new NicolasFlavouredAddressPath(new KeyPath("49'/0'/0'/0/0")), true);
        }
    }
}
