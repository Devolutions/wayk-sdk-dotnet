namespace Devolutions.Wayk.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Threading;

    internal class Renderer : DispatcherObject, INotifyPropertyChanged
    {
        internal delegate void BufferHandleChangedEventHandler(IntPtr handle);

        private readonly object bitmapLock = new object();

        private WriteableBitmap bitmap;

        public event BufferHandleChangedEventHandler OnBufferChanged;

        public IntPtr Buffer { get; private set; }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public int Stride { get; private set; }

        public bool IsInitialized => Buffer != IntPtr.Zero;

        public event PropertyChangedEventHandler PropertyChanged;

        public WriteableBitmap Bitmap
        {
            get => bitmap;

            private set
            {
                bitmap = value;
                RaisePropertyChangedEvent();
            }
        }

        protected void RaisePropertyChangedEvent([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Resize(int width, int height)
        {
            InvokeOnMainThread(delegate
            {
                if (Bitmap == null || Bitmap.PixelWidth != width || Bitmap.PixelHeight != height)
                {
                    InitializeBitmap(width, height);
                }
            });
        }

        public void Invalidate(int x, int y, int width, int height)
        {
            if (!IsInitialized)
            {
                Debug.Write($"{nameof(Renderer)} is not initialized");
                return;
            }

            InvokeOnMainThread(delegate
            {
                lock (bitmapLock)
                {
                    Bitmap.Lock();
                    Bitmap.AddDirtyRect(new Int32Rect(x, y, width, height));
                    Bitmap.Unlock();
                }
            });
        }

        private void InitializeBitmap(int width, int height)
        {
            lock (bitmapLock)
            {
                Bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr32, null);

                Buffer = Bitmap.BackBuffer;
                Width = Bitmap.PixelWidth;
                Height = Bitmap.PixelHeight;
                Stride = Bitmap.BackBufferStride;

                OnBufferChanged?.Invoke(Buffer);
            }
        }

        private void InvokeOnMainThread(Action action)
        {
            if (Thread.CurrentThread.ManagedThreadId == 1)
            {
                action();
            }
            else
            {
                try
                {
                    Dispatcher.Invoke(action);
                }
                catch (TaskCanceledException)
                {
                }
            }
        }
    }
}
