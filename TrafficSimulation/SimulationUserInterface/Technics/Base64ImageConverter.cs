using System;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SimulationUserInterface.Technics
{
    /// <summary>
    /// Converts the Base64 in a XAML usable format for Image tag
    /// </summary>
    public class Base64ImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a Base64 stream into a BitmapImage that can be used for XAML Image
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string s = value as string;

                /// Security check
                if (s == null)
                {
                    return new BitmapImage();
                }

                /// Create an Image
                BitmapImage bi = new BitmapImage();

                /// Translate the stream into an Image
                bi.BeginInit();
                bi.StreamSource = new MemoryStream(System.Convert.FromBase64String(s));
                bi.EndInit();

                return bi;
            }
            catch
            {
                return new BitmapImage();
            }
        }

        /// <summary>
        /// Convert back is not implemented due to no useage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
