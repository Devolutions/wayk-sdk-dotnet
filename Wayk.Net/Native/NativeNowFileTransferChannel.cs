namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransferChannel_Cancel(IntPtr channel, IntPtr session);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowFileTransferChannel_GetSessionById(IntPtr channel, ushort id);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransferChannel_Resume(IntPtr channel, IntPtr session);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransferChannel_Start(IntPtr channel);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransferChannel_Stop(IntPtr channel);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransferChannel_Suspend(IntPtr channel, IntPtr session);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowFileTransferChannel_Retry(IntPtr nowPointer, ref IntPtr session, string filename, int sessionId);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowFileTransferChannel_Create(IntPtr channel, ref IntPtr session, string filename);
	}
}
