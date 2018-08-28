namespace Devolutions.Wayk.Now
{
    using System;
    using static Native.NativeNow;

    public partial class NowAuth : NowObject, IDisposable
    {
        public delegate void NowAuthEventHandler(NowAuth auth);

        private NowPfp pfp;

        public event NowAuthEventHandler OnAuthBegin;
        public event NowAuthEventHandler OnAuthFailure;
        public event NowAuthEventHandler OnAuthSuccess;

        internal NowAuth(IntPtr context)
            : base(context)
        {
            RegisterCallbacks();
        }

        public NowPfp Pfp
        {
            get { return pfp ?? (pfp = new NowPfp(NowAuth_GetPfp(this))); }
        }

        public string Password
        {
            get { return NowAuth_GetPassword(this); }
            set { NowAuth_SetPassword(this, value); }
        }

        public NowAuthType Type
        {
            get { return NowAuth_GetType(this); }
            set { NowAuth_SetType(this, value); }
        }

        public void Init()
        {
            NowAuth_Init(this);
        }
    }
}