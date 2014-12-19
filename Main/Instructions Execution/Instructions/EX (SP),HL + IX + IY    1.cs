﻿
// AUTOGENERATED CODE
//
// Do not make changes directly to this (.cs) file.
// Change "EX (SP),HL + IX + IY    .tt" instead.

namespace Konamiman.Z80dotNet
{
    public partial class Z80InstructionExecutor
    {
        /// <summary>
        /// The EX (SP),HL instruction.
        /// </summary>
        byte EX_aSP_HL()
        {
            FetchFinished();

            var sp = Registers.SP.ToUShort();
            
            var temp = ReadShortFromMemory(sp);
            WriteShortToMemory(sp, Registers.HL);
            Registers.HL = temp;

            return 19;
        }

        /// <summary>
        /// The EX (SP),IX instruction.
        /// </summary>
        byte EX_aSP_IX()
        {
            FetchFinished();

            var sp = Registers.SP.ToUShort();
            
            var temp = ReadShortFromMemory(sp);
            WriteShortToMemory(sp, Registers.IX);
            Registers.IX = temp;

            return 23;
        }

        /// <summary>
        /// The EX (SP),IY instruction.
        /// </summary>
        byte EX_aSP_IY()
        {
            FetchFinished();

            var sp = Registers.SP.ToUShort();
            
            var temp = ReadShortFromMemory(sp);
            WriteShortToMemory(sp, Registers.IY);
            Registers.IY = temp;

            return 23;
        }

    }
}
