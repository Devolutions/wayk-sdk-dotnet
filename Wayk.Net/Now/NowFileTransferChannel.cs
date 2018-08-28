namespace Devolutions.Wayk.Now
{
    using System;
    using static Native.NativeNow;

    public class NowFileTransferChannel : NowChannel
    {
        public NowFileTransferChannel(IntPtr context)
            : base(context)
        {
        }

        public override void Start()
        {
            NowFileTransferChannel_Start(this);
        }

        public override void Stop()
        {
            NowFileTransferChannel_Stop(this);
        }
    }
}