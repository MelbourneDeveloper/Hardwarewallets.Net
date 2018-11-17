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
            var bip44AddressPath = AddressPathBase.Parse<BIP44AddressPath>("m/45/5/3/5'/0'");
            Assert.True(5 == bip44AddressPath.AddressPathElements.Count);

            Assert.True(45 == bip44AddressPath.Purpose);
            Assert.True(5 == bip44AddressPath.CoinType);
            Assert.True(3 == bip44AddressPath.Account);
            Assert.True(5 == bip44AddressPath.Change);
            Assert.True(0 == bip44AddressPath.AddressIndex);

            Assert.True(45 == bip44AddressPath.AddressPathElements[0].UnhardenedValue);
            Assert.False(bip44AddressPath.AddressPathElements[0].Harden);

            Assert.True(5 == bip44AddressPath.AddressPathElements[1].UnhardenedValue);
            Assert.False(bip44AddressPath.AddressPathElements[1].Harden);

            Assert.True(3 == bip44AddressPath.AddressPathElements[2].UnhardenedValue);
            Assert.False(bip44AddressPath.AddressPathElements[2].Harden);

            Assert.True(5 == bip44AddressPath.AddressPathElements[3].UnhardenedValue);
            Assert.True(bip44AddressPath.AddressPathElements[3].Harden);

            Assert.True(2147483653 == bip44AddressPath.ToArray()[3]);

            var customAddressPath = AddressPathBase.Parse<CustomAddressPath>("m/45/5/3/5'");

            Assert.True(2147483653 == customAddressPath.ToArray()[3]);
            Assert.True(5 == customAddressPath.AddressPathElements[3].UnhardenedValue);

            customAddressPath = AddressPathBase.Parse<CustomAddressPath>("0/1/2");

            Assert.True(0 == customAddressPath.AddressPathElements[0].UnhardenedValue);
            Assert.True(1 == customAddressPath.AddressPathElements[1].UnhardenedValue);
            Assert.True(2 == customAddressPath.AddressPathElements[2].UnhardenedValue);
        }
    }
}
