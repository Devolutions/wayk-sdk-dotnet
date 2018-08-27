namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowClipboardChannel_Start(IntPtr channel);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void NowClipboardChannel_Stop(IntPtr channel);
	}
}
