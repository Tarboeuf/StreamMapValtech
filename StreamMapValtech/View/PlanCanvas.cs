using StreamMapValtech.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace StreamMapValtech.View
{
    public class PlanCanvas : Canvas
    {
        public ObservableCollection<PositionVM> ItemsSource
        {
            get { return (ObservableCollection<PositionVM>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemsSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<PositionVM>), typeof(PlanCanvas), new PropertyMetadata(null, new PropertyChangedCallback(ItemsSourceChanged)));

        private static void ItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((PlanCanvas)d).ItemsSourceChanged();
        }
        private void ItemsSourceChanged()
        {
            RefreshSource();
            ItemsSource.CollectionChanged += ItemsSource_CollectionChanged;
        }

        private void ItemsSource_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            RefreshSource();
        }

        public PlanCanvas()
        {
            SizeChanged += PlanCanvas_SizeChanged;
        }

        private void PlanCanvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RefreshSource();
        }
        
        public void RefreshSource()
        {
            Children.Clear();
            if (null != ItemsSource)
            {
                foreach (var item in ItemsSource)
                {
                    Children.Add(new Position(item, this));
                }
            }
        }
    }
}
