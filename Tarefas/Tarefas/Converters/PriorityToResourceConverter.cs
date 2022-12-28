using System;
using System.Globalization;
using Tarefas.Enums;
using Tarefas.Extensions;
using Xamarin.Forms;

namespace Tarefas.Converters
{
    public class PriorityToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            => value is Priority priority
                ? priority.ToColor()
                : throw new ArgumentException($"{value?.GetType().Name} is not a Priority enumeration type");

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
