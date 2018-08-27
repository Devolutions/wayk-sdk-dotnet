namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowFileTransfer_GetSession(IntPtr sessionContext);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowFileTransfer_GetSessions(IntPtr channel);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransfer_GetSessionCounts(IntPtr channel);
	}
}
