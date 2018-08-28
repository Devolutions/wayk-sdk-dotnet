namespace Devolutions.Wayk.Native
{
    using System;
    using System.Runtime.InteropServices;

    internal static class Kernel32
    {
        private const string LibName = "kernel32.dll";

        [DllImport(LibName)]
        public static extern IntPtr LoadLibrary(string path);

        [DllImport(LibName, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);
    }
}