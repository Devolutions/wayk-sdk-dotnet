namespace Devolutions.Wayk.Native
{
	using System;
	using System.Runtime.InteropServices;

	internal static partial class NativeNow
	{
		[DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr NowI18n_Get(bool init);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowI18n_Init(IntPtr i18n);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
		public static extern int NowI18n_SetLanguage(IntPtr i18n, string language);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void NowI18n_Release();
    }
}
