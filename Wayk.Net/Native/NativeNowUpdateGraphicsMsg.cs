namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Pack = 2)]
    internal struct NativeNowUpdateGraphicsMsg
    {
        [FieldOffset(0)] public uint msgSize;

        [FieldOffset(4)] public byte msgFlags;

        [FieldOffset(5)] public byte msgType;

        [FieldOffset(6)] public byte subtype;

        [FieldOffset(7)] public byte flags;

        [FieldOffset(8)] public ushort codecId;

        [FieldOffset(10)] public ushort surfaceId;

        [FieldOffset(12)] public ushort frameId;

        [FieldOffset(14)] public int updateFlags;

        [FieldOffset(18)] public ushort x;

        [FieldOffset(20)] public ushort y;

        [FieldOffset(22)] public ushort width;

        [FieldOffset(24)] public ushort height;

        [FieldOffset(26)] public uint updateSize;

        [FieldOffset(30)] public IntPtr updateData;
    }
}