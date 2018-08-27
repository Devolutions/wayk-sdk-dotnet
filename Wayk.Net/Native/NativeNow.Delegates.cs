namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowChannelOpenEventHandler(IntPtr context, string name, int id, IntPtr iface);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowChannelCloseEventHandler(IntPtr context, string name, int id, IntPtr iface);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowAuthBeginEventHandler(IntPtr context);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowAuthFailureEventHandler(IntPtr context, IntPtr failure);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowAuthSuccessEventHandler(IntPtr context, IntPtr success);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowVerifyCertificateEventHandler(IntPtr context, IntPtr cert, int result, int flags);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowGraphicsUpdateEventHandler(IntPtr context, ref NativeNowUpdateGraphicsMsg graphics);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowSurfaceListRequestEventHandler(IntPtr context, IntPtr listReq);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowSurfaceListResponseEventHandler(IntPtr context, IntPtr listRsp);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowTerminatedEventHandler(IntPtr context, IntPtr sharee);
    
    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowKeyboardGetToggleKeysEventHandler(IntPtr context, IntPtr keyboard);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowKeyboardKeyStateEventHandler(IntPtr context, IntPtr keyboard, int key);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowKeyboardOuputEventHandler(IntPtr context, IntPtr keyboard, int output);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int NativeNowKeyboardToggleEventHandler(IntPtr context, IntPtr keyboard, int toggle);













    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int AccessControlEnableCallback(IntPtr context, IntPtr access, ushort id);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int AccessControlFailureCallback(IntPtr context, IntPtr access, ushort id, ushort reason);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int ClipboardStartCaptureCallback(IntPtr iface);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int OnCloseCallback(IntPtr context, IntPtr sharer, int nstatus);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int OnExecAbortCallback(IntPtr context, IntPtr session, int status, IntPtr param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int OnExecResultCallback(IntPtr context, IntPtr session, int status, IntPtr param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int OnOutputCallback(IntPtr context, IntPtr session, IntPtr output, uint length, bool eof, IntPtr param);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool OnPfpAnswerChallengeCallback(IntPtr context, string question, IntPtr answer, int maxAnswer);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate bool OnPfpChallengeCallback(IntPtr context, IntPtr pfp, IntPtr challenge);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int OnTerminatedCallback(IntPtr context, IntPtr sharee);





    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferAbortCallback(IntPtr context, IntPtr session, IntPtr abort);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferCancelReqCallback(IntPtr context, IntPtr session, IntPtr req);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferCancelRspCallback(IntPtr context, IntPtr session, IntPtr rsp);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferFinishCallback(IntPtr context, IntPtr session);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferResumeReqCallback(IntPtr context, IntPtr session, IntPtr req);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferResumeRspCallback(IntPtr context, IntPtr session, IntPtr rsp);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferRetryRspCallback(IntPtr context, IntPtr session, IntPtr rsp);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferSuspendReqCallback(IntPtr context, IntPtr session, IntPtr req);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferSuspendRspCallback(IntPtr context, IntPtr session, IntPtr rsp);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int FileTransferUpdateCallback(IntPtr context, IntPtr session);





    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int MouseCursorCallback(IntPtr context, IntPtr input, IntPtr cursor);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int MousePositionCallback(IntPtr context, IntPtr input, byte flags, ushort x, ushort y);

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    internal delegate int MouseStateCallback(IntPtr context, IntPtr input, byte state);


}
