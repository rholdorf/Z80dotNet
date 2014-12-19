﻿using System;
using System.Collections.Generic;

namespace Konamiman.Z80dotNet
{
    public partial class Z80InstructionExecutor
    {
        private IDictionary<byte, Func<byte>> FD_InstructionExecutors;

        private void Initialize_FD_InstructionsTable()
        {
            FD_InstructionExecutors = new Dictionary<byte, Func<byte>>
            {
                { 0x09, ADD_IY_BC },
                { 0x19, ADD_IY_DE },
                { 0x21, LD_IY_nn },
                { 0x22, LD_aa_IY },
                { 0x23, INC_IY },
                { 0x24, INC_IYH },
                { 0x25, DEC_IYH },
                { 0x26, LD_IYH_n },
                { 0x29, ADD_IY_IY },
                { 0x2A, LD_IY_aa },
                { 0x2B, DEC_IY },
                { 0x2C, INC_IYL },
                { 0x2D, DEC_IYL },
                { 0x2E, LD_IYL_n },
                { 0x34, INC_aIY_plus_n },
                { 0x35, DEC_aIY_plus_n },
                { 0x36, LD_aIY_plus_n_N },
                { 0x39, ADD_IY_SP },
                { 0x44, LD_B_IYH },
                { 0x45, LD_B_IYL },
                { 0x46, LD_B_aIY_plus_n },
                { 0x4C, LD_C_IYH },
                { 0x4D, LD_C_IYL },
                { 0x4E, LD_C_aIY_plus_n },
                { 0x54, LD_D_IYH },
                { 0x55, LD_D_IYL },
                { 0x56, LD_D_aIY_plus_n },
                { 0x5C, LD_E_IYH },
                { 0x5D, LD_E_IYL },
                { 0x5E, LD_E_aIY_plus_n },
                { 0x60, LD_IYH_B },
                { 0x61, LD_IYH_C },
                { 0x62, LD_IYH_D },
                { 0x63, LD_IYH_E },
                { 0x64, LD_IYH_IYH },
                { 0x65, LD_IYH_IYL },
                { 0x66, LD_H_aIY_plus_n },
                { 0x67, LD_IYH_A },
                { 0x68, LD_IYL_B },
                { 0x69, LD_IYL_C },
                { 0x6A, LD_IYL_D },
                { 0x6B, LD_IYL_E },
                { 0x6C, LD_IYL_H },
                { 0x6D, LD_IYL_IYL },
                { 0x6E, LD_L_aIY_plus_n },
                { 0x6F, LD_IYL_A },
                { 0x70, LD_aIY_plus_n_B },
                { 0x71, LD_aIY_plus_n_C },
                { 0x72, LD_aIY_plus_n_D },
                { 0x73, LD_aIY_plus_n_E },
                { 0x74, LD_aIY_plus_n_H },
                { 0x75, LD_aIY_plus_n_L },
                { 0x77, LD_aIY_plus_n_A },
                { 0x7C, LD_A_IYH },
                { 0x7D, LD_A_IYL },
                { 0x7E, LD_A_aIY_plus_n },
                { 0x84, ADD_A_IYH },
                { 0x85, ADD_A_IYL },
                { 0x86, ADD_A_aIY_plus_n },
                { 0x8C, ADC_A_IYH },
                { 0x8D, ADC_A_IYL },
                { 0x8E, ADC_A_aIY_plus_n },
                { 0x94, SUB_IYH },
                { 0x95, SUB_IYL },
                { 0x96, SUB_aIY_plus_n },
                { 0x9C, SBC_A_IYH },
                { 0x9D, SBC_A_IYL },
                { 0x9E, SBC_A_aIY_plus_n },
                { 0xA4, AND_IYH },
                { 0xA5, AND_IYL },
                { 0xA6, AND_aIY_plus_n },
                { 0xAC, XOR_IYH },
                { 0xAD, XOR_IYL },
                { 0xAE, XOR_aIY_plus_n },
                { 0xB4, OR_IYH },
                { 0xB5, OR_IYL },
                { 0xB6, OR_aIY_plus_n },
                { 0xBC, CP_IYH },
                { 0xBD, CP_IYL },
                { 0xBE, CP_aIY_plus_n },
                { 0xE1, POP_IY },
                { 0xE3, EX_aSP_IY },
                { 0xE5, PUSH_IY },
                { 0xE9, JP_aIY },
                { 0xF9, LD_SP_IY },
            };
        }

        //TODO: Move instructions to their own files when they are implemented.

        /// <summary>
        /// The JP (IY) instruction.
        /// </summary>
        byte JP_aIY()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The LD SP,IY instruction.
        /// </summary>
        byte LD_SP_IY()
        {
            throw new NotImplementedException();
        }
    }
}
