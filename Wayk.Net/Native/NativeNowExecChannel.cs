namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Applescript(IntPtr channel, ref IntPtr session, string content, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Batch(IntPtr channel, ref IntPtr session, string content, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Cancel(IntPtr channel, ref IntPtr session);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Cmd(IntPtr channel, ref IntPtr session, string command, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_PowerShell(IntPtr channel, ref IntPtr session, string content, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Run(IntPtr channel, ref IntPtr session, string command, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Shell(IntPtr channel, ref IntPtr session, string content, string shell, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Execute(IntPtr channel, ref IntPtr session, IntPtr parameters, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Process(IntPtr channel, ref IntPtr session, string filename, string parameters, string directory, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowExecChannel_Stop(IntPtr channel);
    }
}
