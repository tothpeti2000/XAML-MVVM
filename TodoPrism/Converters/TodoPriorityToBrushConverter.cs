using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoPrism.Models;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace TodoPrism.Converters
{
    public class TodoPriorityToBrushConverter : IValueConverter
    {
        public Brush HighPriorityBrush { get; set; }
        public Brush NormalPriorityBrush { get; set; }
        public Brush LowPriorityBrush { get; set; }
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var priority = (Priority)value;
            switch (priority)
            {
                case Priority.High:
                    return HighPriorityBrush;
                case Priority.Normal:
                    return NormalPriorityBrush;
                case Priority.Low:
                    return LowPriorityBrush;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
