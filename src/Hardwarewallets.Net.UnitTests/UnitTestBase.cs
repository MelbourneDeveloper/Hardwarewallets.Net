using Hardwarewallets.Net.AddressManagement;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public abstract class UnitTestBase
    {
        public static IAddressDeriver AddressDeriver { get; protected set; }
        public abstract Task Initialize();

        [Fact]
        public async Task GetBitcoinAddress()
        {
            await Initialize();
            var address = await AddressDeriver.GetAddressAsync(AddressPathBase.Parse<BIP44AddressPath>("49/0/0/0/0"), false, true);
        }

        [Fact]
        public async Task GetBitcoinAddresses()
        {
            await Initialize();

            var addressManager = new AddressManager(AddressDeriver, new BIP44AddressPathFactory(true, 0));

            //Get 10 addresses with all the trimming
            const int numberOfAddresses = 3;
            const int numberOfAccounts = 2;
            var addresses = await addressManager.GetAddressesAsync(0, numberOfAddresses, numberOfAccounts, true, true);

            Assert.True(addresses != null);
            Assert.True(addresses.Accounts != null);
            Assert.True(addresses.Accounts.Count == numberOfAccounts);
            Assert.True(addresses.Accounts[0].Addresses.Count == numberOfAddresses);
            Assert.True(addresses.Accounts[1].Addresses.Count == numberOfAddresses);
            Assert.True(addresses.Accounts[0].ChangeAddresses.Count == numberOfAddresses);
            Assert.True(addresses.Accounts[1].ChangeAddresses.Count == numberOfAddresses);
        }

        [Fact]
        public void TestParser()
        {
            var addressPath = AddressPathBase.Parse<BIP44AddressPath>("m/45/5/3/5'");
            Assert.Equal(4, addressPath.AddressPathElements.Count);

            Assert.Equal(45, (int)addressPath.AddressPathElements[0].UnhardenedValue);
            Assert.False(addressPath.AddressPathElements[0].Harden);

            Assert.Equal(5, (int)addressPath.AddressPathElements[1].UnhardenedValue);
            Assert.False(addressPath.AddressPathElements[1].Harden);

            Assert.Equal(3, (int)addressPath.AddressPathElements[2].UnhardenedValue);
            Assert.False(addressPath.AddressPathElements[2].Harden);

            Assert.Equal(5, (int)addressPath.AddressPathElements[3].UnhardenedValue);
            Assert.True(addressPath.AddressPathElements[3].Harden);
        }
    }
}
