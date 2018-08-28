namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowSettings_GetTargetHostname(IntPtr settings);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string NowSettings_GetTargetPassword(IntPtr settings);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSettings_GetTargetPort(IntPtr settings);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowSettings_New(int argc, string argv);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string NowSettings_GetTargetUsername(IntPtr settings);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowSettings_SetQualityMode(IntPtr settings, int mode);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowSettings_SetTargetHostname(IntPtr settings, string host);
    }
}