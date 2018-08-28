namespace Devolutions.Wayk.Now
{
    using System;
    using Devolutions.Wayk.Native;
    using static Native.NativeNow;

    public partial class NowSharee
    {
        private readonly NativeNowChannelCloseEventHandler onChannelCloseCallback = OnChannelCloseCallback;
        private readonly NativeNowChannelOpenEventHandler onChannelOpenCallback = OnChannelOpenCallback;

        private readonly NativeNowVerifyCertificateEventHandler onVerifyCertificateCallback =
            OnVerifyCertificateCallback;

        private readonly NativeNowGraphicsUpdateEventHandler onGraphicsUpdateCallback = OnGraphicsUpdateCallback;
        private readonly NativeNowSurfaceListRequestEventHandler onSurfaceListReqCallback = OnSurfaceListReqCallback;
        private readonly NativeNowSurfaceListResponseEventHandler onSurfaceListRspCallback = OnSurfaceListRspCallback;
        private readonly NativeNowTerminatedEventHandler onTerminatedCallback = OnTerminatedCallback;

        private void RegisterCallbacks()
        {
            NowSharee_RegisterCallback(this, "VerifyCertificate", onVerifyCertificateCallback, this);
            NowSharee_RegisterCallback(this, "GraphicsUpdate", onGraphicsUpdateCallback, this);
            NowSharee_RegisterCallback(this, "OnSurfaceListReq", onSurfaceListReqCallback, this);
            NowSharee_RegisterCallback(this, "OnSurfaceListRsp", onSurfaceListRspCallback, this);
            NowSharee_RegisterCallback(this, "Terminated", onTerminatedCallback, this);
        }

        private static int OnChannelCloseCallback(IntPtr context, string name, int id, IntPtr iface)
        {
            NowSharee sharee = (NowSharee)context;
            NowObject obj = iface;

            if (obj != null && obj is NowChannel channel)
            {
                channel.Stop();
            }

            return 1;
        }

        private static int OnChannelOpenCallback(IntPtr context, string name, int id, IntPtr iface)
        {
            NowSharee sharee = (NowSharee)context;
            NowChannel channel = null;

            switch (name)
            {
                case "NowClipboard":
                    channel = new NowClipboardChannel(iface);
                    break;
                case "NowFileTransfer":
                    channel = new NowFileTransferChannel(iface);
                    break;
                case "NowExec":
                    channel = new NowExecChannel(iface);
                    break;
            }

            channel?.Start();

            return 1;
        }

        private static int OnVerifyCertificateCallback(IntPtr context, IntPtr cert, int result, int flags)
        {
            NowSharee nowSharee = (NowSharee)context;

            if (nowSharee == null)
            {
                return 0;
            }

            return 1;
        }

        private static int OnGraphicsUpdateCallback(IntPtr context, ref NativeNowUpdateGraphicsMsg graphics)
        {
            NowSharee nowSharee = (NowSharee)context;

            if (nowSharee == null)
            {
                return 0;
            }

            nowSharee.OnGraphicsUpdate?.Invoke(nowSharee, new NowGraphicsUpdateEventArgs(graphics));

            return 1;
        }

        private static int OnSurfaceListReqCallback(IntPtr context, IntPtr listReq)
        {
            NowSharee nowSharee = (NowSharee)context;

            if (nowSharee == null)
            {
                return 0;
            }

            return 1;
        }

        private static int OnSurfaceListRspCallback(IntPtr context, IntPtr listRsp)
        {
            NowSharee nowSharee = (NowSharee)context;

            if (nowSharee == null)
            {
                return 0;
            }

            return 1;
        }

        private static int OnTerminatedCallback(IntPtr context, IntPtr sharee)
        {
            NowSharee nowSharee = (NowSharee)context;

            if (nowSharee == null)
            {
                return 0;
            }

            return 1;
        }
    }
}