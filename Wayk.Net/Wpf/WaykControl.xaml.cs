namespace Devolutions.Wayk.Wpf
{
    using Devolutions.Wayk.Enums;
    using Devolutions.Wayk.Hooks;
    using Devolutions.Wayk.Native;
    using Devolutions.Wayk.Now;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Forms.Integration;
    using System.Windows.Input;
    using System.Windows.Interop;
    using Keys = System.Windows.Forms.Keys;

    public partial class WaykControl
    {
        private static Dictionary<Keys, uint> specialKeys = new Dictionary<Keys, uint>
        {
            [Keys.Back] = 0x0000FF08,
            [Keys.Tab] = 0x0000FF09,
            [Keys.Enter] = 0x0000FF0D,
            [Keys.Escape] = 0x0000FF1B,
            [Keys.Home] = 0x0000FF50,
            [Keys.Left] = 0x0000FF51,
            [Keys.Up] = 0x0000FF52,
            [Keys.Right] = 0x0000FF53,
            [Keys.Down] = 0x0000FF54,
            [Keys.PageUp] = 0x0000FF55,
            [Keys.PageDown] = 0x0000FF56,
            [Keys.End] = 0x0000FF57,
            [Keys.Insert] = 0x0000FF63,
            [Keys.Delete] = 0x0000FFFF,
            [Keys.LWin] = 0x0000FFE3,
            [Keys.RWin] = 0x0000FFEC,
            [Keys.Apps] = 0x0000FFEE,
            [Keys.ShiftKey] = 0x0000FFE1,
            [Keys.LShiftKey] = 0x0000FFE1,
            [Keys.RShiftKey] = 0x0000FFE2,
            [Keys.Alt] = 0x0000FFE9,
            [Keys.Menu] = 0x0000FFE9,
            [Keys.LMenu] = 0x0000FFE9,
            [Keys.RMenu] = 0x0000FFEA,
            [Keys.ControlKey] = 0x0000FFE3,
            [Keys.LControlKey] = 0x0000FFE3,
            [Keys.RControlKey] = 0x0000FFE4,
            [Keys.F1] = 0x0000FFBE,
            [Keys.F2] = 0x0000FFBF,
            [Keys.F3] = 0x0000FFC0,
            [Keys.F4] = 0x0000FFC1,
            [Keys.F5] = 0x0000FFC2,
            [Keys.F6] = 0x0000FFC3,
            [Keys.F7] = 0x0000FFC4,
            [Keys.F8] = 0x0000FFC5,
            [Keys.F9] = 0x0000FFC6,
            [Keys.F10] = 0x0000FFC7,
            [Keys.F11] = 0x0000FFC8,
            [Keys.F12] = 0x0000FFC9
        };

        private HashSet<uint> pressedKeys = new HashSet<uint>();
        private Renderer renderer;
        private NowSharee sharee;
        private NowDen den;
        private NowI18n i18n;

        public WaykControl()
        {
            renderer = new Renderer();

            InitializeComponent();

            Binding binding = new Binding();
            binding.Source = renderer;
            binding.Path = new PropertyPath("Bitmap");

            image.SetBinding(Image.SourceProperty, binding);
        }

        ~WaykControl()
        {
            KeyboardHook.OnMessage -= KeyboardHook_OnMessage;
        }

        public bool Connect(string target, string password)
        {
            this.sharee = new NowSharee();
            this.den = new NowDen();
            this.i18n = new NowI18n();

            this.den.EditEnter();
            this.den.Url = NowDen.DefaultAddress;
            this.den.Enabled = true;
            this.den.OnDemand = true;
            this.den.EditLeave();

            if (!this.den.Start())
            {
                return false;
            }

            this.sharee.Den = this.den;

            this.sharee.Auth.OnAuthBegin += auth =>
            {
                auth.Password = password;
                auth.Type = NowAuthType.Srp;
                auth.Init();
            };

            bool connected = this.sharee.Connect(target);

            if (!connected)
            {
                return false;
            }

            this.sharee.OnGraphicsUpdate += (sharee, args) =>
            {
                sharee.Codec.Decode(this.renderer.Buffer, this.renderer.Stride, args.X, args.Y, args.Width, args.Height,
                    args.Buffer, args.BufferSize, args.CodecId);
                this.renderer.Invalidate(args.X, args.Y, args.Width, args.Height);
            };

            this.sharee.Codec.SetSize(this.sharee.SurfaceWidth, this.sharee.SurfaceHeight);
            this.renderer.Resize(this.sharee.SurfaceWidth, this.sharee.SurfaceHeight);

            this.sharee.Start();

            return true;
        }

        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(this);

            if (e.ChangedButton == MouseButton.XButton1 || e.ChangedButton == MouseButton.XButton2)
            {
                return;
            }

            Point position = GetPosition(e);
            MouseButtons buttons = GetButtons(e);

            sharee.SendMouseEvent((byte)GetMouseFlags(buttons, buttons != MouseButtons.None), (int)position.X,
                (int)position.Y);
        }

        private void Control_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Keyboard.Focus(this);

            if (e.ChangedButton == MouseButton.XButton1 || e.ChangedButton == MouseButton.XButton2)
            {
                return;
            }

            Point position = GetPosition(e);
            MouseButtons buttons = GetButtons(e);

            sharee.SendMouseEvent((byte)GetMouseFlags(buttons, buttons != MouseButtons.None), (int)position.X,
                (int)position.Y);
        }

        private void Control_MouseMove(object sender, MouseEventArgs e)
        {
            Point position = GetPosition(e);
            MouseButtons buttons = GetButtons(e);

            sharee.SendMouseEvent((byte)GetMouseFlags(buttons, buttons != MouseButtons.None), (int)position.X,
                (int)position.Y);
        }

        private void Control_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            Point position = GetPosition(e);
            MouseButtons buttons = GetButtons(e);

            sharee.SendScrollEvent((byte)GetMouseFlags(buttons, buttons != MouseButtons.None), 0, (int)e.Delta);
        }

        private Point GetPosition(MouseEventArgs args)
        {
            Point position = args.GetPosition(image);

            position.X /= image.ActualWidth;
            position.Y /= image.ActualHeight;

            position.X *= renderer.Width;
            position.Y *= renderer.Height;

            return position;
        }

        private MouseButtons GetButtons(MouseEventArgs args)
        {
            MouseButtons buttons = MouseButtons.None;

            if (args.LeftButton == MouseButtonState.Pressed)
            {
                buttons |= MouseButtons.Left;
            }

            if (args.RightButton == MouseButtonState.Pressed)
            {
                buttons |= MouseButtons.Right;
            }

            if (args.MiddleButton == MouseButtonState.Pressed)
            {
                buttons |= MouseButtons.Middle;
            }

            return buttons;
        }

        private int GetMouseFlags(MouseButtons buttons, bool down)
        {
            return (down ? NativeNow.MouseDown : 0) | GetMouseButtonFlags(buttons);
        }

        private int GetMouseButtonFlags(MouseButtons button)
        {
            int flags = 0;

            if (button.HasFlag(MouseButtons.Left)) flags = NativeNow.MouseLeft;
            if (button.HasFlag(MouseButtons.Right)) flags = NativeNow.MouseRight;
            if (button.HasFlag(MouseButtons.Middle)) flags = NativeNow.MouseMiddle;

            return flags;
        }

        private void KeyboardHook_OnMessage(int nCode, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            Window window = Window.GetWindow(this);

            if (Keyboard.FocusedElement != this || (window != null && !window.IsActive))
            {
                return;
            }

            User32.LowLevelKeyboardStruct param = Marshal.PtrToStructure<User32.LowLevelKeyboardStruct>(lParam);
            bool extended = (param.Flags & User32.LLKHF_EXTENDED) != 0;
            int input = param.VkCode;

            if (extended && param.VkCode != NativeNow.VK_RSHIFT)
            {
                input |= (1 << 8);
            }

            if (wParam == (IntPtr)WindowsMessage.WM_KEYDOWN || wParam == (IntPtr)WindowsMessage.WM_SYSKEYDOWN)
            {
                sharee.Keyboard.Input(input | (1 << 16));
                handled = true;
            }
            else if (wParam == (IntPtr)WindowsMessage.WM_KEYUP || wParam == (IntPtr)WindowsMessage.WM_SYSKEYUP)
            {
                sharee.Keyboard.Input(input);
                handled = true;
            }
        }

        private void Self_Loaded(object sender, RoutedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                KeyboardHook.OnMessage += KeyboardHook_OnMessage;
            }
        }
    }
}