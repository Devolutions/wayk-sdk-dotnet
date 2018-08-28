namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowSharee_GetAuth(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowSharee_GetCodec(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_CheckEventHandles(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_Closing(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_Connect(IntPtr sharee, string hostname, int port, uint timeout,
            IntPtr handle);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_ConnectWithDenID(IntPtr sharee, string targetId, int timeout, IntPtr handle);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_ConnectUrl(IntPtr sharee, string url, int timeout, IntPtr handle);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_Free(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint NowSharee_GetEventHandles(IntPtr sharee, ref IntPtr handles);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern NowState NowSharee_GetState(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint NowSharee_GetStatus(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_GetSurfaceHeight(IntPtr surfaceManager);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_GetSurfaceWidth(IntPtr surfaceManager);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr NowSharee_New(IntPtr settings);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowSharee_RegisterCallback(IntPtr sharee, string name, Delegate function,
            IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_SendAssociateRequest(IntPtr sharee, ushort flags, uint sessionId);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_SendKeyboardEvent(IntPtr sharee, byte flags, ushort keys);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_SendMouseEvent(IntPtr sharee, byte flags, int x, int y);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_SendScrollEvent(IntPtr sharee, byte flags, int x, int y);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_SendToggleEvent(IntPtr sharee, byte flags, ushort keys);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowSharee_SetPassword(IntPtr sharee, string password);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowSharee_SetUsername(IntPtr sharee, string username);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowSharee_SetDen(IntPtr sharee, IntPtr den);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowSharee_Start(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowSharee_Close(IntPtr sharee, int nstatus);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowSharee_SendUnicodeEvent(IntPtr intPtr, byte flags, byte[] x);
    }
}