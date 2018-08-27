namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr WinPR_CreateEvent(IntPtr lpEventAttributes, bool bManualReset, bool bInitialState, IntPtr lpName);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool WinPR_SetEvent(IntPtr handle);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool WinPR_ResetEvent(IntPtr handle);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool WinPR_CloseHandle(IntPtr handle);
	}
}
