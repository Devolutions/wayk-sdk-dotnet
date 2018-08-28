namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;
    using Devolutions.Wayk.Utilities;

    internal static partial class NativeNow
    {
        public const string LibName = "DevolutionsWayk.dll";
        public const uint INFINITE = 0xFFFFFFFF;
        public const uint WAIT_FAILED = 0xFFFFFFFF;
        public const uint WAIT_TIMEOUT = 0x00000102;
        public const uint WAIT_OBJECT_0 = 0x00000000;
        public const uint WAIT_ABANDONED_0 = 0x00000080;

        public const int VK_CAPITAL = 20;
        public const int VK_KANA = 21;
        public const int VK_SPACE = 32;
        public const int VK_PRIOR = 33;
        public const int VK_NEXT = 34;
        public const int VK_END = 35;
        public const int VK_HOME = 36;
        public const int VK_LEFT = 37;
        public const int VK_UP = 38;
        public const int VK_RIGHT = 39;
        public const int VK_DOWN = 40;
        public const int VK_SELECT = 41;
        public const int VK_PRINT = 42;
        public const int VK_EXECUTE = 43;
        public const int VK_SNAPSHOT = 44;
        public const int VK_INSERT = 45;
        public const int VK_DELETE = 46;
        public const int VK_HELP = 47;
        public const int VK_LWIN = 91;
        public const int VK_RWIN = 92;
        public const int VK_APPS = 93;
        public const int VK_NUMLOCK = 144;
        public const int VK_SCROLL = 145;
        public const int VK_LSHIFT = 160;
        public const int VK_RSHIFT = 161;
        public const int VK_LCONTROL = 162;
        public const int VK_RCONTROL = 163;
        public const int VK_LMENU = 164;
        public const int VK_RMENU = 165;

        public const int KeyDown = 0x4000;
        public const int KeyExtended = 0x0100;
        public const int KeyUp = 0x8000;
        public const int MouseDown = 0x8000;
        public const int MouseMove = 0x0800;
        public const int MouseWheelDown = 0x0200;
        public const int MouseWheelUp = MouseWheelDown | 0x0100;
        public const int MouseLeft = 0x0001;
        public const int MouseRight = 0x0002;
        public const int MouseMiddle = 0x0004;

        static NativeNow()
        {
            NativeLibraryHelper.LoadEmbeddedLibrary(typeof(NativeNow).Assembly, LibName);
        }

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr GetFileTransferChannel(IntPtr channel);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowT(string value);

        [DllImport("Kernel32", CallingConvention = CallingConvention.Cdecl)]
        public static extern bool SetEnvironmentVariableA(string name, string value = null);
    }
}