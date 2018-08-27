namespace Devolutions.Wayk.Now
{
    using System;

    public abstract class NowChannel : NowObject
    {
        public NowChannel(IntPtr context)
            : base(context)
        {
        }

        public abstract void Start();
        public abstract void Stop();
    }
}
