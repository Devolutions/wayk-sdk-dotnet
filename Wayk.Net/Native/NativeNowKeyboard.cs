namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowKeyboard_New();

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowKeyboard_Input(IntPtr keyboard, int input);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowKeyboard_RegisterCallback(IntPtr auth, string name, Delegate function,
            IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowKeyboard_Free(IntPtr keyboard);
    }
}