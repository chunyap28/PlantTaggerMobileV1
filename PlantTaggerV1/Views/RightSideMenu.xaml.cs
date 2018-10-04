using System;
using System.Collections.Generic;
using SlideOverKit;
using Xamarin.Forms;
using System.Windows.Input;
using System.Threading.Tasks;

namespace PlantTaggerV1.Views
{
    public partial class RightSideMenu : SlideMenuView
    {
        public event EventHandler MenuItemTapped;

        public RightSideMenu()
        {
            InitializeComponent();

            this.IsFullScreen = true;
            // You must set WidthRequest in this case
            this.WidthRequest = 250;
            this.MenuOrientations = MenuOrientation.RightToLeft;

            // You must set BackgroundColor, 
            // and you cannot put another layout with background color cover the whole View
            // otherwise, it cannot be dragged on Android
            this.BackgroundColor = Color.FromHex("#D8DDE7"); 

            // This is shadow view color, you can set a transparent color
            this.BackgroundViewColor = Color.Transparent;
        }

        public ListView ListView
        {
            get => this.listView;

            set => this.listView = value;
        }

        private void OnItemTapped(ListView sender, ItemTappedEventArgs e)
        {
            var handler = MenuItemTapped;
            if (handler != null)
                handler(this, e);

            sender.SelectedItem = null;
        }
    }
}
