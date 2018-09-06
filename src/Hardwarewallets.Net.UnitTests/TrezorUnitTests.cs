using Hid.Net;
using System;
using System.Linq;
using System.Threading.Tasks;
using Trezor.Net;
using Xunit;

namespace Hardwarewallets.Net.UnitTests
{
    public class TrezorUnitTests
    {
        private static TrezorManager TrezorManager;

        [Fact]
        public async Task GetTrezorBitcoinAddress()
        {
            await GetAndInitialize();
            var trezorManagerWrapper = new TrezorManagerWrapper(TrezorManager);
            var address = await trezorManagerWrapper.GetAddressAsync(new AddressPath(true, 0, 0, false, 0), true);
        }

        private async Task GetAndInitialize()
        {
            if (TrezorManager != null)
            {
                return;
            }

            var trezorHidDevice = await Connect();
            TrezorManager = new TrezorManager(GetPin, trezorHidDevice);
            await TrezorManager.InitializeAsync();
        }

        private async Task<IHidDevice> Connect()
        {
            DeviceInformation trezorDeviceInformation = null;

            WindowsHidDevice retVal = null;

            retVal = new WindowsHidDevice();

            Console.Write("Waiting for Trezor .");

            while (trezorDeviceInformation == null)
            {
                var devices = WindowsHidDevice.GetConnectedDeviceInformations();
                var trezors = devices.Where(d => d.VendorId == TrezorManager.TrezorVendorId && TrezorManager.TrezorProductId == 1).ToList();
                trezorDeviceInformation = trezors.FirstOrDefault(t => t.Product == TrezorManager.USBOneName);

                if (trezorDeviceInformation != null)
                {
                    break;
                }

                await Task.Delay(1000);
                Console.Write(".");
            }

            retVal.DeviceInformation = trezorDeviceInformation;

            await retVal.InitializeAsync();

            Console.WriteLine("Connected");

            return retVal;
        }

        private async Task<string> GetPin()
        {
            throw new Exception("The pin needs to be initialized before running the unit test");
        }
    }
}
