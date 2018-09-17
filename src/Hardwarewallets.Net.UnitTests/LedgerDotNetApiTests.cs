using LedgerWallet;
using NBitcoin;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public class LedgerDotNetApiTests : UnitTestBase
    {
        public override async Task Initialize()
        {
            var ledgerClient = (await LedgerClient.GetHIDLedgersAsync()).First();
            HardwarewalletManager = new LedgerDotNetApiWrapper(ledgerClient);
        }
    }
}
