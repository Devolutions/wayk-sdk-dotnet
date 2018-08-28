namespace Devolutions.Wayk.Now
{
    using System;
    using static Native.NativeNow;

    public class NowClipboardChannel : NowChannel
    {
        public NowClipboardChannel(IntPtr context)
            : base(context)
        {
        }

        public override void Start()
        {
            NowClipboardChannel_Start(this);
        }

        public override void Stop()
        {
            NowClipboardChannel_Stop(this);
        }
    }
}