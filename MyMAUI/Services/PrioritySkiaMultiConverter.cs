using SkiaSharp.Extended.UI.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MyMAUI.Models.QuizEntity;

namespace MyMAUI.Services
{

    public class PrioritySkiaMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            //PriorityQuiz, SKLottieView 순서대로 values 배열에 넣음
            return new PrioritySkia((PriorityQuiz)values[0], (SKLottieView)values[1], (ImageButton)values[2]);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            //Mode = "TwoWay" 일때 사용
            throw new NotImplementedException();
        }

    }

}
