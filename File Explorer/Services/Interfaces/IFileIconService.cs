namespace FileExplorer.Services.Interfaces
{
    using System.Windows.Media.Imaging;

    internal interface IFileIconService
    {
        BitmapSource GetImage(string path);
    }
}