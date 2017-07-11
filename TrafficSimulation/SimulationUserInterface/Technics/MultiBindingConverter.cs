using System;
using System.Globalization;
using System.Windows.Data;

namespace SimulationUserInterface.Technics
{

    /// <summary>
    /// converter to create a multi binding for the UI
    /// </summary>
    public class MultiBindingConverter : IMultiValueConverter
    {

        /// <summary>
        /// Convert
        /// </summary>
        /// <param name="values"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            return values.Clone();
        }

        /// <summary>
        /// Convert Back (Not implemented)
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetTypes"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
