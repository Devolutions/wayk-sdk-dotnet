namespace Devolutions.Wayk.Now
{
    using System;
    using Devolutions.Wayk.Native;

    public class NowGraphicsUpdateEventArgs : EventArgs
    {
        public ushort CodecId { get; }

        public ushort X { get; }

        public ushort Y { get; }

        public ushort Width { get; }

        public ushort Height { get; }

        public uint BufferSize { get; }

        public IntPtr Buffer { get; }

        internal NowGraphicsUpdateEventArgs(NativeNowUpdateGraphicsMsg msg)
        {
            CodecId = msg.codecId;
            X = msg.x;
            Y = msg.y;
            Width = msg.width;
            Height = msg.height;
            BufferSize = msg.updateSize;
            Buffer = msg.updateData;
        }
    }
}