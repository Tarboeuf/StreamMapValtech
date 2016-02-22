using StreamMapValtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StreamMapValtech.View
{
    public class Position : Control
    {
        PositionVM _position;
        PlanCanvas _canvas;

        public Position()
        {

        }

        public Position(PositionVM position, PlanCanvas canvas)
        {
            _position = position;
            _canvas = canvas;

            X = position.X * canvas.ActualWidth;
            Y = position.Y * canvas.ActualHeight;
            OldX = position.OldX * canvas.ActualWidth;
            OldY = position.OldY * canvas.ActualHeight;
        }



        #region position

        public double X
        {
            get { return (double)GetValue(XProperty); }
            set { SetValue(XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register("X", typeof(double), typeof(Position), new PropertyMetadata(0d));

        public double Y
        {
            get { return (double)GetValue(YProperty); }
            set { SetValue(YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register("Y", typeof(double), typeof(Position), new PropertyMetadata(0d));

        public double OldX
        {
            get { return (double)GetValue(OldXProperty); }
            set { SetValue(OldXProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OldX.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OldXProperty =
            DependencyProperty.Register("OldX", typeof(double), typeof(Position), new PropertyMetadata(0d));

        public double OldY
        {
            get { return (double)GetValue(OldYProperty); }
            set { SetValue(OldYProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OldY.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OldYProperty =
            DependencyProperty.Register("OldY", typeof(double), typeof(Position), new PropertyMetadata(0d));

        #endregion
    }
}
