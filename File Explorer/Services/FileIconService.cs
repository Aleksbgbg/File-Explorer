namespace FileExplorer.Services
{
    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media.Imaging;

    using FileExplorer.Services.Interfaces;

    internal class FileIconService : IFileIconService
    {
        private const uint ImageFlag = 0x100;

        public BitmapSource GetImage(string path)
        {
            IntPtr iconHandle = IntPtr.Zero;

            SHGetFileInfo(path, 0, ref iconHandle, (uint)Marshal.SizeOf(iconHandle), ImageFlag);

            return Imaging.CreateBitmapSourceFromHBitmap(Icon.FromHandle(iconHandle).ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string filePath, uint fileAttributes, ref IntPtr shellFileInfoPointer, uint fileSizeInfo, uint flags);
    }
}