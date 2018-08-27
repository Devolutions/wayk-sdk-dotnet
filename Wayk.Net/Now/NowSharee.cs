namespace Devolutions.Wayk.Now
{
    using System;
    using Devolutions.Wayk.Native;

    using static Native.NativeNow;

    public partial class NowSharee : NowObject
    {
        public delegate void NowShareeGraphicsUpdateEventHandler(NowSharee sharee, NowGraphicsUpdateEventArgs args);

        private NowAuth auth;
        private NowCodec codec;
        private NowKeyboard keyboard;

        static NowSharee()
        {
            NowTransport_WSAStartup();
        }

        public NowSharee()
            : base(NowSharee_New(NowSettings_New(0, null)))
        {
            RegisterCallbacks();
        }

        public event NowShareeGraphicsUpdateEventHandler OnGraphicsUpdate;

        public NowAuth Auth => auth ?? (auth = new NowAuth(NowSharee_GetAuth(this)));

        public NowCodec Codec => codec ?? (codec = new NowCodec(NowSharee_GetCodec(this)));

        public NowKeyboard Keyboard => keyboard ?? (keyboard = new NowKeyboard(this));

        internal NowState State => NowSharee_GetState(this);

        public uint Status => NowSharee_GetStatus(this);

        public string StatusText => NowStatus_GetText(Status);

        public int SurfaceHeight => NowSharee_GetSurfaceHeight(this);

        public int SurfaceWidth => NowSharee_GetSurfaceWidth(this);

        public NowDen Den
        {
            set
            {
                NowSharee_SetDen(this, value);
            }
        }

        public void Start()
        {
            NowSharee_Start(this);
        }

        public void Close(int nstatus)
        {
            NowSharee_Close(this, nstatus);
        }

        public bool Connect(string hostname)
        {
            IntPtr cancelEvent = WinPR_CreateEvent(IntPtr.Zero, true, false, IntPtr.Zero);
            int status = NowSharee_ConnectUrl(this, hostname, 10000, cancelEvent);
            IntPtr[] events = new IntPtr[64];
            uint count = 0;
            uint wait;

            while (status > 0)
            {
                count = 0;
                events[count++] = cancelEvent;
                count += NowSharee_GetEventHandles(this, ref events[count]);

                wait = NowTie_WaitForMultipleObjects(count, events, false, INFINITE);

                if (wait == WAIT_OBJECT_0 + count - 1)
                {
                    return false;
                }

                if (wait == WAIT_FAILED)
                {
                    throw new Exception("WaitForMultipleObjects returned WAIT_FAILED");
                }

                status = NowSharee_CheckEventHandles(this);

                if (status <= 0)
                {
                    throw new Exception(StatusText);
                }

                if (State == NowState.Active)
                {
                    return true;
                }

                if (State == NowState.Final)
                {
                    return false;
                }
            }

            return status == 1;
        }

        public void SendMouseEvent(byte flags, int x, int y)
        {
            NowSharee_SendMouseEvent(this, flags, x, y);
        }

        public void SendScrollEvent(byte flags, int x, int y)
        {
            NowSharee_SendScrollEvent(this, flags, x, y);
        }

        public void SendToggleEvent(byte flags, ushort keys)
        {
            NowSharee_SendToggleEvent(this, flags, keys);
        }

        public void SendKeyboardEvent(byte flags, ushort keys)
        {
            NowSharee_SendKeyboardEvent(this, flags, keys);
        }

        public override void Dispose()
        {
            base.Dispose();

            NowSharee_Free(this);
        }
    }
}
