using Hardwarewallets.Net.AddressManagement;
using System;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public abstract class UnitTestBase
    {
        //TODO: Unit tests have been disabled until the latest changes have been rolled in to all libraries.

        public static IAddressDeriver AddressDeriver { get; protected set; }
        public abstract Task Initialize();

        //[Fact]
        //public async Task GetBitcoinAddress()
        //{
        //    await Initialize();
        //    var address = await AddressDeriver.GetAddressAsync(AddressPathBase.Parse<BIP44AddressPath>("49/0/0/0/0"), false, true);
        //}

        //[Fact]
        //public async Task GetBitcoinAddresses()
        //{
        //    await Initialize();

        //    var addressManager = new AddressManager(AddressDeriver, new BIP44AddressPathFactory(true, 0));

        //    //Get 10 addresses with all the trimming
        //    const int numberOfAddresses = 3;
        //    const int numberOfAccounts = 2;
        //    var addresses = await addressManager.GetAddressesAsync(0, numberOfAddresses, numberOfAccounts, true, true);

        //    Assert.True(addresses != null);
        //    Assert.True(addresses.Accounts != null);
        //    Assert.True(addresses.Accounts.Count == numberOfAccounts);
        //    Assert.True(addresses.Accounts[0].Addresses.Count == numberOfAddresses);
        //    Assert.True(addresses.Accounts[1].Addresses.Count == numberOfAddresses);
        //    Assert.True(addresses.Accounts[0].ChangeAddresses.Count == numberOfAddresses);
        //    Assert.True(addresses.Accounts[1].ChangeAddresses.Count == numberOfAddresses);
        //}

        [Fact]
        public void TestParser()
        {
            var pathAsString = "m/45/5/3/5'/0'";
            var customAddressPath = AddressPathBase.Parse<CustomAddressPath>(pathAsString);

            Assert.Equal(pathAsString, customAddressPath.ToString());

            Assert.True(5 == customAddressPath.AddressPathElements.Count);

            Assert.True(45 == customAddressPath.AddressPathElements[0].Value);
            Assert.False(customAddressPath.AddressPathElements[0].Harden);

            Assert.True(5 == customAddressPath.AddressPathElements[1].Value);
            Assert.False(customAddressPath.AddressPathElements[1].Harden);

            Assert.True(3 == customAddressPath.AddressPathElements[2].Value);
            Assert.False(customAddressPath.AddressPathElements[2].Harden);

            Assert.True(5 == customAddressPath.AddressPathElements[3].Value);
            Assert.True(customAddressPath.AddressPathElements[3].Harden);

            Assert.True(2147483653 == customAddressPath.ToArray()[3]);

            pathAsString = "m/45/5/3/5'";
            customAddressPath = AddressPathBase.Parse<CustomAddressPath>(pathAsString);
            Assert.Equal(pathAsString, customAddressPath.ToString());

            Assert.True(2147483653 == customAddressPath.ToArray()[3]);
            Assert.True(5 == customAddressPath.AddressPathElements[3].Value);

            customAddressPath = AddressPathBase.Parse<CustomAddressPath>("0/1/2");

            Assert.True(0 == customAddressPath.AddressPathElements[0].Value);
            Assert.True(1 == customAddressPath.AddressPathElements[1].Value);
            Assert.True(2 == customAddressPath.AddressPathElements[2].Value);

            var bip44AddressPath = AddressPathBase.Parse<BIP44AddressPath>("44'/0'/0'/0/0");

            Assert.True(44 == bip44AddressPath.Purpose);
            Assert.True(0 == bip44AddressPath.CoinType);
            Assert.True(0 == bip44AddressPath.Account);
            Assert.True(0 == bip44AddressPath.Change);
            Assert.True(0 == bip44AddressPath.AddressIndex);

            Assert.True(bip44AddressPath.ToArray()[0] == 2147483692);

            var sb = new StringBuilder();
            sb.Append("m");
            for (var i = 0; i < 100; i++)
            {
                sb.Append($"/{i}{(i % 2 == 0 ? "'" : string.Empty)}");
            }
            customAddressPath = AddressPathBase.Parse<CustomAddressPath>(sb.ToString());
            for (var i = 0; i < 100; i++)
            {
                Assert.True(customAddressPath.AddressPathElements[i].Harden == (i % 2 == 0));
            }

            Assert.Equal(sb.ToString(), customAddressPath.ToString());

            Exception validationException = null;
            try
            {
                bip44AddressPath = AddressPathBase.Parse<BIP44AddressPath>("44'/0'/0/0/0");
                bip44AddressPath.Validate();
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
            Assert.NotNull(validationException);

            validationException = null;
            try
            {
                bip44AddressPath = AddressPathBase.Parse<BIP44AddressPath>("50'/0'/0'/0/0");
                bip44AddressPath.Validate();
            }
            catch (Exception ex)
            {
                validationException = ex;
            }
            Assert.NotNull(validationException);
        }
    }
}
