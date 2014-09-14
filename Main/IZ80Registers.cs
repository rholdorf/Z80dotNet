namespace Konamiman.Z80dotNet
{
    /// <summary>
    /// Represents a full set of Z80 registers.
    /// </summary>
    public interface IZ80Registers
    {
        /// <summary>
        /// The main register set (AF, BC, DE, HL)
        /// </summary>
        IMainZ80Registers Main { get; set; }

        /// <summary>
        /// The alternate register set (AF', BC', DE', HL')
        /// </summary>
        IMainZ80Registers Alternate { get; set; }

        /// <summary>
        /// The IX register pair
        /// </summary>
        short IX { get; set; }

        /// <summary>
        /// The IY register pair
        /// </summary>
        short IY { get; set; }

        /// <summary>
        /// The program counter
        /// </summary>
        ushort PC { get; set; }

        /// <summary>
        /// The stack pointer
        /// </summary>
        short SP { get; set; }

        /// <summary>
        /// The interrupt and refresh register
        /// </summary>
        short IR { get; set; }

        /// <summary>
        /// The IFF1 flag. It has always the value 0 or 1.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Attempt to set a value other than 0 or 1</exception>
        Bit IFF1 { get; set; }

        /// <summary>
        /// The IFF2 flag. It has always the value 0 or 1.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Attempt to set a value other than 0 or 1</exception>
        Bit IFF2 { get; set; }

        /// <summary>
        /// The IXh register.
        /// </summary>
        byte IXh { get; set; }

        /// <summary>
        /// The IXl register.
        /// </summary>
        byte IXl { get; set; }

        /// <summary>
        /// The IYh register.
        /// </summary>
        byte IYh { get; set; }

        /// <summary>
        /// The IYl register.
        /// </summary>
        byte IYl { get; set; }

        /// <summary>
        /// The I register.
        /// </summary>
        byte I { get; set; }

        /// <summary>
        /// The R register.
        /// </summary>
        byte R { get; set; }
    }
}