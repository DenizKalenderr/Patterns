using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using static Patterns.Model.MainModel;
//using ModernDashboard.Model;


namespace Patterns.ViewModel
{
    internal class NavigationViewModel : INotifyPropertyChanged
    {
        private CollectionViewSource _menuItemsCollection;
        //public event PropertyChangedEventHandler? PropertyChanged;

        public ICollectionView SourceCollection => _menuItemsCollection.View;

        public NavigationViewModel()
        {
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems { MenuName = "Home", MenuImage = @"Assets/home.png",
                },
                new MenuItems
                {
                    MenuName = "Design Patterns",
                    MenuImage = "Assets/home.png",


                },
                new MenuItems { MenuName = "Architectural Patterns", MenuImage = @"Assets/data.png",

                },
                new MenuItems { MenuName = "Solid", MenuImage = "principle.png",

                }
            };

            _menuItemsCollection = new CollectionViewSource { Source = menuItems };
            _menuItemsCollection.Filter += MenuItems_Filter;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                _filterText = value;
                _menuItemsCollection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }

        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(_filterText))
            {
                e.Accepted = true;
                return;
            }
            MenuItems _item = e.Item as MenuItems;
            if (_item.MenuName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
    }
}