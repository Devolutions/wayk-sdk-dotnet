namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static partial class NativeNow
    {
        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowCodec_Decode(IntPtr ctx, IntPtr dstData, int dstStep, int x, int y, int width, int height, IntPtr srcData, uint srcSize, ushort codecId);

        [DllImport(LibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern bool NowCodec_SetSize(IntPtr input, int width, int height);
    }
}
