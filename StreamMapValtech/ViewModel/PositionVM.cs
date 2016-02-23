using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamMapValtech.ViewModel
{
    public class PositionVM : INotifyPropertyChanged
    {
        private double _X;
        public double X
        {
            get
            {
                return _X;
            }
            set
            {
                _X = value;
                OnPropertyChanged(nameof(X));
            }
        }

        private double _Y;
        public double Y
        {
            get
            {
                return _Y;
            }
            set
            {
                _Y = value;
                OnPropertyChanged(nameof(Y));
            }
        }

        private double _OldX;
        public double OldX
        {
            get
            {
                return _OldX;
            }
            set
            {
                _OldX = value;
                OnPropertyChanged(nameof(OldX));
            }
        }

        private double _OldY;
        public double OldY
        {
            get
            {
                return _OldY;
            }
            set
            {
                _OldY = value;
                OnPropertyChanged(nameof(OldY));
            }
        }

        public int Id { get; internal set; }

        private static Random _Random = new Random();


        public static PositionVM GenererFake()
        {
            PositionVM p = new PositionVM();
            p.X = _Random.NextDouble();
            p.Y = _Random.NextDouble();
            p.OldX = _Random.NextDouble();
            p.OldY = _Random.NextDouble();
            return p;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            if (null != PropertyChanged)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
