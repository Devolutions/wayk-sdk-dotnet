namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool NowAccessControl_RegisterCallback(IntPtr access, string name, Delegate function, IntPtr param);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowAccessControl_SendRequest(IntPtr access, ushort id, ushort timeout);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool NowAccessControl_IsEnabled(IntPtr access, ushort id);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern bool NowAccessControl_CanEnable(IntPtr access, ushort id);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowAccessControl_GetReasonText(int id, int reason);
	}
}
