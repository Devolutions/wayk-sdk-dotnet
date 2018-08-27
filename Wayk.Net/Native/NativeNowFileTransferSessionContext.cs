namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern ushort NowFileTransferSessionContext_GetId(IntPtr session);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransferSessionContext_GetTransferSize(IntPtr session);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern string NowFileTransferSessionContext_GetFileName(IntPtr session);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern long NowFileTransferSessionContext_GetFileSize(IntPtr session);
    }
}
