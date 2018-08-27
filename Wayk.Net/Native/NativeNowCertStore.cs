namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowCertStore_VerifyCert(IntPtr store, IntPtr cert, string hostname, int port);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowCertStore_AddException(IntPtr store, IntPtr cert, string hostname, int port);
	}
}
