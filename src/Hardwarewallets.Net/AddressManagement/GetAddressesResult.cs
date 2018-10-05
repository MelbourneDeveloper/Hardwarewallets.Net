using System.Collections.ObjectModel;

namespace Hardwarewallets.Net.AddressManagement
{
    public class GetAddressesResult
    {
        public Collection<AccountResult> Accounts { get; } = new Collection<AccountResult>();
    }
}
