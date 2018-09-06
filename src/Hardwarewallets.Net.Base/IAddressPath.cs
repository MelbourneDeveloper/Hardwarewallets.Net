namespace Hardwarewallets.Net.Base
{
    internal interface IAddressPath
    {
        uint Purpose { get; }
        uint CoinType { get; }
        uint Account { get; }
        uint Change { get; }
        uint AddressIndex { get; }
        uint[] ToArray();
    }
}
