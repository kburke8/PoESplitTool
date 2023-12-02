using System.Globalization;
using System.Windows.Data;
using System.Windows;
using PoESplitTimer;

namespace PoESplitTimer
{

    public class ShowWhenStoppedAndNotZeroConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is bool isRunning && values[1] is TimeSpan elapsed)
            {
                return !isRunning && elapsed.TotalSeconds > 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    public class ShowWhenStoppedAndZeroConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is bool isRunning && values[1] is TimeSpan elapsed)
            {
                return !isRunning && elapsed.TotalSeconds == 0 ? Visibility.Visible : Visibility.Collapsed;
            }
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}