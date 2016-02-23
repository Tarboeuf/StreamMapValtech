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

        public int IdPosition { get; set; }

        public Position()
        {

        }

        public Position(PositionVM position, PlanCanvas canvas)
        {
            _position = position;
            _canvas = canvas;

            position.PropertyChanged += Position_PropertyChanged;

            UpdateProperties();
            IdPosition = position.Id;
        }

        private void Position_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateProperties();
        }

        private void UpdateProperties()
        {
            X = _position.X * _canvas.ActualWidth;
            Y = _position.Y * _canvas.ActualHeight;
            OldX = _position.OldX * _canvas.ActualWidth;
            OldY = _position.OldY * _canvas.ActualHeight;
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



        public double BigCircle
        {
            get { return (double)GetValue(BigCircleProperty); }
            set { SetValue(BigCircleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BigCircle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BigCircleProperty =
            DependencyProperty.Register("BigCircle", typeof(double), typeof(Position), new PropertyMetadata(8d));



        public double SmallCircle
        {
            get { return (double)GetValue(SmallCircleProperty); }
            set { SetValue(SmallCircleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SmallCircle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SmallCircleProperty =
            DependencyProperty.Register("SmallCircle", typeof(double), typeof(Position), new PropertyMetadata(2d));
        


        #endregion
    }
}
