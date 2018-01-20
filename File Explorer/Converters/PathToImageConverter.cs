namespace FileExplorer.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;
    using System.Windows.Media.Imaging;

    using Caliburn.Micro;

    using FileExplorer.Services.Interfaces;

    [ValueConversion(typeof(string), typeof(BitmapImage))]
    internal class PathToImageConverter : IValueConverter
    {
        private readonly IFileIconService fileIconService = IoC.Get<IFileIconService>();

        public static PathToImageConverter Instance { get; } = new PathToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return fileIconService.GetImage((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}