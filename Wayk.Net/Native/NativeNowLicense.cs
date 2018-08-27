namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowLicense_IsTrial(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowLicense_IsProduct(IntPtr license, byte product);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowLicense_IsType(IntPtr license, byte type);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte NowLicense_GetFlags(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte NowLicense_GetProduct(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern byte NowLicense_GetType(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowLicense_GetCount(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string NowLicense_GetExpirationString(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowLicense_GetExpirationDate(IntPtr license, ref int day, ref int month, ref int year);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowLicense_IsExpired(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowLicense_Parse(IntPtr license, string serial);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowLicense_Match(IntPtr license, byte product, byte type);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowLicense_IsLegacy(IntPtr license);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowLicense_New();

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowLicense_Free(IntPtr ctx);
    }
}
