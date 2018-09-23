using Hardwarewallets.Net.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hardwarewallets.Net.Addresses
{
    public class AddressManager
    {
        #region Public Properties
        public IHardwarewalletManager HardwarewalletManager { get; }
        public IAddressPathFactory AddressPathFactory { get; }
        private uint Purpose { get; }
        private uint CoinType { get; }
        #endregion

        #region Constructor

        public AddressManager(IHardwarewalletManager hardwarewalletManager, IAddressPathFactory addressPathFactory)
        {
            HardwarewalletManager = hardwarewalletManager;
            AddressPathFactory = addressPathFactory;
        }

        public AddressManager(IHardwarewalletManager hardwarewalletManager, IAddressPathFactory addressPathFactory, bool isSegit, uint cointType) : this(hardwarewalletManager, addressPathFactory)
        {
            Purpose = isSegit ? (uint)49 : 44;
            CoinType = cointType;
        }
        #endregion

        public async Task<GetAddressesResult> GetAddressesAsync(uint startIndex, int numberOfAddresses, int numberOfAccounts, bool includeChangeAddresses, bool includePublicKeys)
        {
            var retVal = new GetAddressesResult();

            //Iterate through accounts
            for (uint account = 0; account < numberOfAccounts + numberOfAddresses; account++)
            {
                var addresses = new List<PathResult>();
                List<PathResult> changeAddresses = null;
                if (includeChangeAddresses)
                {
                    changeAddresses = new List<PathResult>();
                }

                //Create the result for the account
                var accountResult = new AccountResult(account, addresses, changeAddresses);

                //Iterate through address indexes
                for (var i = 0; i < numberOfAddresses; i++)
                {

                    var addressPath = AddressPathFactory.GetAddressPath(0, account, startIndex + (uint)i);

                    var address = await HardwarewalletManager.GetAddressAsync(AddressPathFactory.GetAddressPath(0, account, startIndex + i), false);

                    string publicKey = null;
                    if (includePublicKeys)
                    {
                        publicKey = await HardwarewalletManager.GetPublicKeyAsync(addressPath, false);
                    }

                    accountResult.Addresses.Add(new PathResult(publicKey, address));
                }
            }
        }
    }
}
