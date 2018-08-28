namespace Devolutions.Wayk.Now
{
    using static Native.NativeNow;

    public partial class NowKeyboard : NowObject
    {
        private NowSharee sharee;

        public NowKeyboard(NowSharee sharee)
            : base(NowKeyboard_New())
        {
            this.sharee = sharee;

            RegisterCallbacks();
        }

        public override void Dispose()
        {
            base.Dispose();

            NowKeyboard_Free(this);
        }

        public void Input(int input)
        {
            NowKeyboard_Input(this, input);
        }
    }
}