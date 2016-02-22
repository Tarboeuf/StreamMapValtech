using StreamMapValtech.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace StreamMapValtech.ViewModel
{
    public class PlanVM : INotifyPropertyChanged
    {
        private PlanModel _model;

        public string Name { get; set; }

        private string _PathImage;
        public string PathImage {
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

        public Uri Image { get
            {
                return new Uri(PathImage);
            }
        }

        public ObservableCollection<PositionVM> Positions { get; set; }

        public PlanVM()
        {
            Positions = new ObservableCollection<PositionVM> {
                PositionVM.GenererFake() ,
                PositionVM.GenererFake() ,
                PositionVM.GenererFake()
            };
            InitialiserFake();
        }

        private void InitialiserFake()
        {
            PathImage = @"ms-appx:///ImageTemp/ValtechFP1.png";
            Name = "Valtech Etage 2";
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
