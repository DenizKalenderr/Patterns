using System.Collections.ObjectModel;

namespace Patterns.Model
{
    public class MainModel
    {
        public class MenuItems
        {
            public string MenuName { get; set; }
            public string MenuImage { get; set; }

            public ObservableCollection<SubItems> SubMenuItems { get; set; }
        }

        public class SubItems
        {
            public string SubMenuName { get; set; }
            public string SubMenuImage { get; set; }
    }


}
}
