namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowSurfaceManager_GetSurface(IntPtr surfaceManager, ushort index);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort NowSurfaceManager_GetSurfaceId(IntPtr surfaceManager);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern ushort NowSurfaceManager_GetSurfaceCount(IntPtr surfaceManager);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSurfaceManager_SelectSurface(IntPtr surfaceManager, ushort index);
    }
}