﻿namespace Hardwarewallets.Net.Model
{
    /// <summary>
    /// An broken up in to its constituent parts for the purpose of performing operations on a Hardwarewallet device.
    /// </summary>
    public interface IAddressPath
    {
        /// <summary>
        /// Returns the address path as an array of uints. Indices will be hardended or unhardened depending on their IsHardened property
        /// </summary>
        uint[] ToArray();
    }
}
