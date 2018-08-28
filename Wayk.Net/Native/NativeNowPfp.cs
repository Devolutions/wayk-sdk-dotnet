namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowPfp_GetQuestion(IntPtr pfp);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowPfp_RegisterCallback(IntPtr auth, string name, Delegate function, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowPfp_SetAnswer(IntPtr pfp, string answer);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowPfp_SetFriendlyName(IntPtr auth, string name);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowPfp_SetFriendlyText(IntPtr auth, string text);
    }
}