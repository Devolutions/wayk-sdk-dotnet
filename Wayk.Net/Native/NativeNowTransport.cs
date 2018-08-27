namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowTie_WSACleanup();

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowTransport_WSAStartup();
    }
}
