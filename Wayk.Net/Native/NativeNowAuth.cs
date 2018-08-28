namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;
    using Devolutions.Wayk.Now;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowAuth_Free(IntPtr auth);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowAuth_GetPfp(IntPtr auth);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowAuth_Init(IntPtr auth);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowAuth_IsSupported(IntPtr auth, int type);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowAuth_RegisterCallback(IntPtr auth, string name, Delegate function, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string NowAuth_GetPassword(IntPtr auth);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowAuth_SetPassword(IntPtr auth, string password);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowAuth_SetType(IntPtr auth, NowAuthType type);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern NowAuthType NowAuth_GetType(IntPtr auth);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowAuth_SetUsername(IntPtr auth, string username);
    }
}