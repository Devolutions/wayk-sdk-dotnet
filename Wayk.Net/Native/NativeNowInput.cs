namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void NowInput_Free(IntPtr input);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool NowInput_IsEnabled(IntPtr input);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool NowInput_RegisterCallback(IntPtr auth, string name, Delegate function, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern void NowInput_ToggleViewOnlyMode(IntPtr input);
	}
}
