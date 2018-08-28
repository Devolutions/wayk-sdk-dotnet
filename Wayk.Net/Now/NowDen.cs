namespace Devolutions.Wayk.Now
{
    using System;
    using static Native.NativeNow;

    public class NowDen : NowObject, IDisposable
    {
        public const string DefaultAddress = "wss://den.wayk.net";

        public string Url
        {
            get { return NowDen_GetUrl(this); }
            set { NowDen_SetUrl(this, value); }
        }

        public bool Enabled
        {
            get { return NowDen_GetEnabled(this); }
            set { NowDen_SetEnabled(this, value); }
        }

        public bool OnDemand
        {
            get { return NowDen_GetOnDemand(this); }
            set { NowDen_SetOnDemand(this, value); }
        }

        public NowDen()
            : base(NowDen_Get(DefaultAddress))
        {
        }

        public bool Start()
        {
            return NowDen_Start(this);
        }

        public void EditEnter()
        {
            NowDen_EditEnter(this);
        }

        public void EditLeave()
        {
            NowDen_EditLeave(this);
        }

        public override void Dispose()
        {
            base.Dispose();
            NowDen_Release(this);
        }
    }
}