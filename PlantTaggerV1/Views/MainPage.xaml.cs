using System;
using PlantTaggerV1.ViewModels;
using Xamarin.Forms;
using SlideOverKit;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace PlantTaggerV1.Views
{
    public partial class MainPage : ContentPage, IMenuContainerPage
    {
        private RightSideMenu _rightSideMenu = new RightSideMenu();

        public MainPage()
        {
            InitializeComponent();
            SlideMenu = _rightSideMenu;
            this._rightSideMenu.MenuItemTapped += OnMenuItemTapped;
        }

        public Action HideMenuAction
        {
            get;
            set;
        }

        public Action ShowMenuAction
        {
            get;
            set;
        }

        public SlideMenuView SlideMenu
        {
            get;
            set;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _rightSideMenu.BindingContext = BindingContext;
            setupSideMenuItems();
        }

        private void setupSideMenuItems(){
            ObservableCollection<MenuItem> menuItems = new ObservableCollection<MenuItem>();

            MenuItem settingsItem = new MenuItem();
            settingsItem.Text = "Settings";
            MenuItem logoutItem = new MenuItem();
            logoutItem.Text = "Logout";
            logoutItem.SetBinding(MenuItem.CommandProperty, new Binding("LogoutCommand", source: BindingContext));

            menuItems.Add(settingsItem);
            menuItems.Add(logoutItem);
            this._rightSideMenu.ListView.ItemsSource = menuItems;
        }

        private void OnMenuItemTapped(Object sender, EventArgs e)
        {
            //System.Diagnostics.Debug.WriteLine("OnMenuItemTapped: close side menu here");
            ItemTappedEventArgs args = e as ItemTappedEventArgs;
            if( args != null ){
                MenuItem item = args.Item as MenuItem;
                if (item != null && item.Command != null)
                {
                    item.Command.Execute(item);
                }    
            }

            HideMenuAction?.Invoke();
        }

        private void OnSideMenuRequested(object sender, EventArgs e){
            //System.Diagnostics.Debug.WriteLine("OnSideMenuRequested");
            if (SlideMenu.IsShown)
            {
                HideMenuAction?.Invoke();
            }
            else
            {
                ShowMenuAction?.Invoke();
            }
        }
    }
}
