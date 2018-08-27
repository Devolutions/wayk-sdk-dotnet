namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowShared_GetAccessControl(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowShared_GetInput(IntPtr sharee);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowShared_GetSurfaceManager(IntPtr sharee);
	}
}
