using Hardwarewallets.Net.Addresses;
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

        [Fact]
        public async Task GetBitcoinAddresses()
        {
            await Initialize();

            var addressManager = new AddressManager(HardwarewalletManager, new AddressPathFactory(true, 0));

            //Get 10 addresses with all the trimming
            const int numberOfAddresses = 3;
            const int NumberOfAccounts = 2;
            var addresses = await addressManager.GetAddressesAsync(0, numberOfAddresses, NumberOfAccounts, true, true);

            Assert.True(addresses != null);
            Assert.True(addresses.Accounts != null);
            Assert.True(addresses.Accounts.Count == NumberOfAccounts);
            Assert.True(addresses.Accounts[0].Addresses.Count == numberOfAddresses);
            Assert.True(addresses.Accounts[1].Addresses.Count == numberOfAddresses);
            Assert.True(addresses.Accounts[0].ChangeAddresses.Count == numberOfAddresses);
            Assert.True(addresses.Accounts[1].ChangeAddresses.Count == numberOfAddresses);

        }
    }
}
