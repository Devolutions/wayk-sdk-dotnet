using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Devolutions.Wayk.Native
{
    internal static class User32
    {
        private const string LibName = "user32.dll";

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);

        public const int WH_KEYBOARD_LL = 13;
        public const int LLKHF_EXTENDED = 1;

        [DllImport(LibName)]
        public static extern uint MapVirtualKey(uint uCode, uint uMapType);

        [DllImport(LibName)]
        public static extern int ToUnicodeEx(
            uint wVirtKey,
            uint wScanCode,
            byte[] lpKeyState,
            [Out, MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszBuff,
            int cchBuff,
            uint wFlags,
            IntPtr dwhkl);

        [DllImport(LibName)]
        public static extern short GetAsyncKeyState(System.Windows.Forms.Keys vKey);

        [DllImport(LibName)]
        public static extern IntPtr GetKeyboardLayout(uint idThread);

        [DllImport(LibName)]
        public static extern bool GetKeyboardState(byte[] lpKeyState);

        [DllImport(LibName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

        [DllImport(LibName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, LowLevelKeyboardProc lpfn, IntPtr hMod,
            uint dwThreadId);

        [DllImport(LibName, CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [StructLayout(LayoutKind.Sequential)]
        public struct LowLevelKeyboardStruct
        {
            public int VkCode;

            public int ScanCode;

            public int Flags;

            public int Time;

            public IntPtr Extra;
        }
    }
}