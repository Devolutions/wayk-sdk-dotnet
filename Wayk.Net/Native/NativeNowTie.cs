namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowTie_SetCallback(IntPtr channel, string name, Delegate function);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int NowTie_SetRemoteExecCallback(IntPtr channel, string name, Delegate function);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowTie_CreateCursorHandle(IntPtr cursor);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern uint NowTie_WaitForMultipleObjects(uint count, IntPtr[] handles, bool waitAll, UInt32 milliseconds);
    }
}
