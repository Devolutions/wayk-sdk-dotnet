namespace Devolutions.Wayk.Now
{
    using static Native.NativeNow;

    public class NowLicense : NowObject
    {
        public NowLicense()
            : base(NowLicense_New())
        {
        }
    }
}
