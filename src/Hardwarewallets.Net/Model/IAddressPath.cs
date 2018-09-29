namespace Hardwarewallets.Net.Model
{
    /// <summary>
    /// BIP 004 Address Path broken up in to its constituent parts. https://github.com/bitcoin/bips/blob/master/bip-0044.mediawiki
    /// </summary>
    public interface IAddressPath
    {
        /// <summary>
        /// Unhardened Purpose. This will be hardened when ToHardenedArray() is called.
        /// </summary>
        uint Purpose { get; }

        /// <summary>
        /// Unhardened CoinType. This will be hardened when ToHardenedArray() is called.
        /// </summary>
        uint CoinType { get; }

        /// <summary>
        /// Unhardened Account. This will be hardened when ToHardenedArray() is called.
        /// </summary>
        uint Account { get; }

        /// <summary>
        /// Unhardened Change. This will be not hardened when ToHardenedArray() is called.
        /// </summary>
        uint Change { get; }

        /// <summary>
        /// Unhardened AddressIndex. This will be not hardened when ToHardenedArray() is called.
        /// </summary>
        uint AddressIndex { get; }

        /// <summary>
        /// Returns the BIP44 address path as an array of uints. The first three indices are hardened but the last two are not. 
        /// </summary>
        uint[] ToUnhardenedArray();

        /// <summary>
        /// Returns the BIP44 address path as an array of uints. No indices are hardened
        /// </summary>
        uint[] ToHardenedArray();
    }
}
