namespace Devolutions.Wayk.Extensions
{
    using System.Windows.Forms;

    internal static class InputExtensions
    {
        public static MouseButtons ToMouseButton(this System.Windows.Input.MouseButton button)
        {
            switch (button)
            {
                case System.Windows.Input.MouseButton.Middle: return MouseButtons.Middle;
                case System.Windows.Input.MouseButton.Right: return MouseButtons.Right;
                default: return MouseButtons.Left;
            }
        }
    }
}