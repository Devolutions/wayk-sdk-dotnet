namespace Devolutions.Wayk.Now
{
    using System;

    using static Native.NativeNow;

    public class NowCodec : NowObject
    {
        public NowCodec(IntPtr context)
            : base(context)
        {
        }

        public void SetSize(int width, int height)
        {
            NowCodec_SetSize(this, width, height);
        }

        public void Decode(IntPtr destination, int dstStep, int x, int y, int width, int height, IntPtr source, uint sourceSize, ushort codecId)
        {
            NowCodec_Decode(this, destination, dstStep, x, y, width, height, source, sourceSize, codecId);
        }
    }
}
