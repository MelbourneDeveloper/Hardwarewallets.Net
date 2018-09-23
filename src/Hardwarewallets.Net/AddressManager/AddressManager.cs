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

            for (uint account = 0; account < numberOfAccounts + numberOfAddresses; account++)
            {
                var addresses = new List<PathInformation>();
                List<PathInformation> changeAddresses = null;
                if (includeChangeAddresses)
                {
                    changeAddresses = new List<PathInformation>(numberOfAddresses);
                }

                for (uint i = 0; i < numberOfAddresses; i++)
                {
                    var accountResult = new AccountResult(account, addresses, changeAddresses);

                    var addressPath = AddressPathFactory.GetAddressPath(0, account, startIndex + i);
                    var address = await HardwarewalletManager.GetAddressAsync(AddressPathFactory.GetAddressPath(0, account, startIndex + i), false);
                    
                }


            }
        }
    }
}
