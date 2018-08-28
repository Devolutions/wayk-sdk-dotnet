namespace Devolutions.Wayk.Now
{
    using Devolutions.Wayk.Native;
    using System;
    using System.Runtime.InteropServices;
    using static Native.NativeNow;

    public partial class NowKeyboard
    {
        private readonly NativeNowKeyboardGetToggleKeysEventHandler onKeyboardGetToggleKeys = OnKeyboardGetToggleKeys;
        private readonly NativeNowKeyboardKeyStateEventHandler onKeyboardKeyState = OnKeyboardKeyState;
        private readonly NativeNowKeyboardOuputEventHandler onKeyboardOuput = OnKeyboardOuput;
        private readonly NativeNowKeyboardToggleEventHandler onKeyboardToggle = OnKeyboardToggle;

        private static int OnKeyboardGetToggleKeys(IntPtr context, IntPtr keyboard)
        {
            int GetKeyState(int key)
            {
                return User32.GetAsyncKeyState((System.Windows.Forms.Keys)key) & 0x8000;
            }

            int keys = 0;

            if ((GetKeyState(VK_SCROLL) & 1) != 0)
            {
                keys |= 1;
            }
            else if ((GetKeyState(VK_NUMLOCK) & 1) != 0)
            {
                keys |= 2;
            }
            else if ((GetKeyState(VK_CAPITAL) & 1) != 0)
            {
                keys |= 4;
            }
            else if ((GetKeyState(VK_KANA) & 1) != 0)
            {
                keys |= 8;
            }

            return keys;
        }

        private static int OnKeyboardKeyState(IntPtr context, IntPtr keyboard, int key)
        {
            return 0x8001;
        }

        private static int OnKeyboardOuput(IntPtr context, IntPtr keyboard, int output)
        {
            NowKeyboard nowKeyboard = (NowKeyboard)context;

            byte flags = (byte)((output >> 16) & 0xFF);
            ushort code = (ushort)(output & 0xFFFF);

            nowKeyboard.sharee.SendKeyboardEvent(flags, code);

            return 1;
        }

        private static int OnKeyboardToggle(IntPtr context, IntPtr keyboard, int toggle)
        {
            NowKeyboard nowKeyboard = (NowKeyboard)context;

            byte flags = (byte)((toggle >> 16) & 0xFF);
            ushort code = (ushort)(toggle & 0xFFFF);

            nowKeyboard.sharee.SendKeyboardEvent(flags, code);

            return 1;
        }

        private void RegisterCallbacks()
        {
            NowKeyboard_RegisterCallback(this, "OnOutput", this.onKeyboardOuput, this);
            NowKeyboard_RegisterCallback(this, "GetToggleKeys", this.onKeyboardGetToggleKeys, this);
            NowKeyboard_RegisterCallback(this, "OnToggle", this.onKeyboardToggle, this);
            NowKeyboard_RegisterCallback(this, "GetKeyState", this.onKeyboardKeyState, this);
        }
    }
}