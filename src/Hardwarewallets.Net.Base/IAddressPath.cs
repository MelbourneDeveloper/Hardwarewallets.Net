namespace Hardwarewallets.Net.Base
{
    /// <summary>
    /// BIP 004 Address Path broken up in to its constituent parts. https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki
    /// </summary>
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
