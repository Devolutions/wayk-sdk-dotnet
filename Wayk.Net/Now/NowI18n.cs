namespace Devolutions.Wayk.Now
{
    using System;

    using static Native.NativeNow;

    public class NowI18n : NowObject, IDisposable
    {
        public NowI18n()
            : base(NowI18n_Get(false))
        {
            NowI18n_SetLanguage(Context, "en");
            NowI18n_Init(Context);
        }

        public override void Dispose()
        {
            base.Dispose();
            NowI18n_Release();
        }
    }
}
