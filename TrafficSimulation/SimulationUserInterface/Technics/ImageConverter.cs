using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SimulationUserInterface.Technics
{
    public class ImageConverter : IValueConverter
    {
        /// <summary>
        /// Converts a Imagpath ina XAML usable format for Image tag
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                string s = value as string;

                /// Security check
                if (s == null)
                {
                    return new BitmapImage();
                }

                /// Return the new image created out of the path
                return new BitmapImage(new Uri(s));
            }
            catch
            {
                return new BitmapImage();
            }

        }

        /// <summary>
        /// Convert back is not implemented due to no usage
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
