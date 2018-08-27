namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowDen_EditEnter(IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowDen_EditLeave(IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowDen_SetEnabled(IntPtr den, bool enabled);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowDen_GetEnabled(IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string NowDen_GetUrl(IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowDen_SetUrl(IntPtr den, string url);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowDen_SetSettings(IntPtr den, IntPtr settings);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowDen_Get(string url);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowDen_Release(IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool NowDen_Start(IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowDen_GetOnDemand(IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowDen_SetOnDemand(IntPtr den, bool onDemand);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowDen_RegisterCallback(IntPtr den, string name, Delegate function, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowDen_Resolve(IntPtr den, string name, UInt32 peerId, int timeout, IntPtr cancelEvent);
    }
}
