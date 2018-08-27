namespace Devolutions.Wayk.Native
{
    internal enum NowState
    {
        Initial,
        Handshake,
        Negotiate,
        Authenticate,
        Associate,
        Capabilities,
        Channels,
        Active,
        Final
    }
}
