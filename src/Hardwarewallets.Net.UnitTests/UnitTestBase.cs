using Hardwarewallets.Net.Base;
using System.Threading.Tasks;

namespace Hardwarewallets.Net.UnitTests
{
    public abstract class UnitTestBase
    {
        public static IHardwarewalletManager HardwarewalletManager { get; protected set; }
        public abstract Task Initialize();
        public abstract Task GetBitcoinAddress();
    }
}
