﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Unfair.Util
{
    public static class Memory
    {
        [DllImport("Kernel32.dll", EntryPoint = "VirtualProtect")]
        private static extern bool VirtualProtect(IntPtr address, uint size, uint flNewProtect, out uint flOldProtect);

        public static void WriteBytes(IntPtr address, byte[] bytes)
        {
            for (int i = 0; i < bytes.Length; i++) WriteByte(address + i, bytes[i]);
        }

        public static byte[] ReadBytes(IntPtr address, int size)
        {
            List<byte> buffer = new List<byte>();
            for (int i = 0; i < size; i++)
            {
                buffer.Add(ReadByte(address + i));
            }

            return buffer.ToArray();
        }

        public static unsafe void WriteInt(IntPtr address, int intToWrite)
        {
            VirtualProtect(address, sizeof(int), 0x40, out uint oldProtect);
            *(int*)address = intToWrite;
            VirtualProtect(address, sizeof(int), oldProtect, out oldProtect);
        }

        public static unsafe void WriteLong(IntPtr address, long longToWrite)
        {
            VirtualProtect(address, sizeof(long), 0x40, out uint oldProtect);
            *(long*)address = longToWrite;
            VirtualProtect(address, sizeof(long), oldProtect, out oldProtect);
        }

        public static unsafe void WriteByte(IntPtr address, byte byteToWrite)
        {
            VirtualProtect(address, sizeof(byte), 0x40, out uint oldProtect);
            *(byte*)address = byteToWrite;
            VirtualProtect(address, sizeof(byte), oldProtect, out oldProtect);
        }

        public static unsafe byte ReadByte(IntPtr address)
        {
            VirtualProtect(address, sizeof(byte), 0x40, out uint oldProtect); // In case its not even readable
            byte targetByte = *(byte*)address;
            VirtualProtect(address, sizeof(byte), oldProtect, out oldProtect);
            return targetByte;
        }
    }
}