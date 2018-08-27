namespace Devolutions.Wayk.Now
{
    using System;
    using Devolutions.Wayk.Native;

    using static Native.NativeNow;

    public partial class NowAuth
    {
        private readonly NativeNowAuthBeginEventHandler onClientBeginCallback = OnClientBeginCallback;
        private readonly NativeNowAuthFailureEventHandler onAuthFailureCallback = OnAuthSuccessCallback;
        private readonly NativeNowAuthSuccessEventHandler onAuthSuccessCallback = OnAuthSuccessCallback;

        private void RegisterCallbacks()
        {
            NowAuth_RegisterCallback(this, "OnClientBegin", onClientBeginCallback, this);
            NowAuth_RegisterCallback(this, "OnFailure", onAuthFailureCallback, this);
            NowAuth_RegisterCallback(this, "OnSuccess", onAuthSuccessCallback, this);
        }

        private static int OnClientBeginCallback(IntPtr auth)
        {
            NowAuth nowAuth = (NowAuth)auth;
            nowAuth?.OnAuthBegin?.Invoke(nowAuth);
            return 1;
        }

        private static int OnAuthFailureCallback(IntPtr auth, IntPtr success)
        {
            NowAuth nowAuth = (NowAuth)auth;
            nowAuth?.OnAuthFailure?.Invoke(nowAuth);
            return 1;
        }

        private static int OnAuthSuccessCallback(IntPtr auth, IntPtr success)
        {
            NowAuth nowAuth = (NowAuth)auth;
            nowAuth?.OnAuthSuccess?.Invoke(nowAuth);
            return 1;
        }
    }
}
