namespace Devolutions.Wayk.Now
{
    using System;
    using static Native.NativeNow;

    internal class NowExecChannel : NowChannel
    {
        internal NowExecChannel(IntPtr context)
            : base(context)
        {
        }

        public override void Start()
        {
            NowExecChannel_Stop(this);
        }

        public override void Stop()
        {
            NowExecChannel_Stop(this);
        }
    }
}