namespace Devolutions.Wayk.Hooks
{
    using System;
    using System.Diagnostics;
    using Devolutions.Wayk.Native;

    internal static class KeyboardHook
    {
        private static volatile User32.LowLevelKeyboardProc hookCallback = HookCallback;

        private static IntPtr hookID;

        public delegate void KeyBoardHookMessageEventHandler(int nCode, IntPtr wParam, IntPtr lParam, ref bool handled);

        public static event KeyBoardHookMessageEventHandler OnMessage
        {
            add
            {
                onMessage += value;

                if (onMessage != null)
                {
                    Hook();
                }
            }

            remove
            {
                onMessage -= value;

                if (onMessage == null)
                {
                    Unhook();
                }
            }
        }

        private static event KeyBoardHookMessageEventHandler onMessage;

        private static void Hook()
        {
            if (hookID != IntPtr.Zero)
            {
                return;
            }

            hookID = User32.SetWindowsHookEx(User32.WH_KEYBOARD_LL, hookCallback,
                Kernel32.GetModuleHandle(Process.GetCurrentProcess().MainModule.ModuleName), 0);
        }

        private static void Unhook()
        {
            if (hookID == IntPtr.Zero)
            {
                return;
            }

            User32.UnhookWindowsHookEx(hookID);

            hookID = IntPtr.Zero;
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            bool handled = false;

            onMessage?.Invoke(nCode, wParam, lParam, ref handled);

            if (handled)
            {
                return (IntPtr)1;
            }

            return User32.CallNextHookEx(hookID, nCode, wParam, lParam);
        }
    }
}