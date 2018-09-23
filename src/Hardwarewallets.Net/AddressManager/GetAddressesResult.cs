using System.Collections.ObjectModel;

namespace Hardwarewallets.Net.Addresses
{
    public class GetAddressesResult
    {
        public Collection<AccountResult> Accounts { get; } = new Collection<AccountResult>();
    }
}
