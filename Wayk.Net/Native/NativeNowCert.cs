namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowCert_GetRawData(IntPtr cert, ref IntPtr data);
	}
}
