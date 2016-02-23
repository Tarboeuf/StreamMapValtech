using StreamMapValtech.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace StreamMapValtech.ViewModel
{
    public class PlanVM : INotifyPropertyChanged
    {
        private PlanModel _model;
        private Random _random = new Random();

        public string Name { get; set; }

        private string _PathImage;
        public string PathImage
        {
            get
            {
                return _PathImage;
            }
            set
            {
                _PathImage = value;
                OnPropertyChanged(nameof(_PathImage));
                OnPropertyChanged(nameof(Image));
            }
        }

        public Uri Image
        {
            get
            {
                return new Uri(PathImage);
            }
        }

        private ObservableCollection<PositionVM> _positions;
        public ObservableCollection<PositionVM> Positions
        {
            get
            {
                return _positions;
            }
            set
            {
                _positions = value;
                OnPropertyChanged(nameof(Positions));
            }
        }

        public PlanVM()
        {
            GenererPositions();
            InitialiserFake();
        }

        private void ModifierPositions()
        {
            if(_random.Next(10) <= 2)
            {
                Positions.Add(PositionVM.GenererFake());
            }

            if (_random.Next(10) == 4)
            {
                Positions.RemoveAt(0);
            }

            foreach (var item in Positions)
            {
                item.OldX = item.X;
                item.OldY = item.Y;
                item.X = Math.Min(1, item.X * (_random.NextDouble() / 6 + 1 - 1d / 12));
                item.Y = Math.Min(1, item.Y * (_random.NextDouble() / 6 + 1 - 1d / 12));
            }
        }

        private void GenererPositions()
        {
            Positions = new ObservableCollection<PositionVM> {
                PositionVM.GenererFake() ,
                PositionVM.GenererFake() ,
                PositionVM.GenererFake()
            };
        }

        private void InitialiserFake()
        {
            PathImage = @"ms-appx:///ImageTemp/ValtechFP1.png";
            Name = "Valtech Etage 2";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        public ICommand GenererCommand { get { return new DelegateCommand(o => ModifierPositions(), null); } }
    }
}
