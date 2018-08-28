namespace Devolutions.Wayk.Utilities
{
    using Devolutions.Wayk.Native;
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;

    internal static partial class NativeLibraryHelper
    {
        public static void LoadEmbeddedLibrary(Assembly assembly, string libName)
        {
            string tempDir = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());
            string dllPath = Path.Combine(tempDir, libName);

            if (!Directory.Exists(tempDir))
            {
                Directory.CreateDirectory(tempDir);
            }

            string suffix = $"x{(Environment.Is64BitProcess ? "64" : "86")}.{libName}";

            string resourceName = assembly.GetManifestResourceNames().FirstOrDefault(n => n.EndsWith(suffix));

            if (string.IsNullOrEmpty(resourceName))
            {
                throw new EmbeddedAssemblyLoadException(
                    $"Could not load library named \"{resourceName}\" from assembly {assembly.FullName}");
            }

            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            {
                byte[] data = new BinaryReader(stream).ReadBytes((int) stream.Length);
                File.WriteAllBytes(dllPath, data);
                Kernel32.LoadLibrary(dllPath);
            }
        }

        public class EmbeddedAssemblyLoadException : Exception
        {
            public EmbeddedAssemblyLoadException(string message)
                : base(message)
            {
            }
        }
    }
}