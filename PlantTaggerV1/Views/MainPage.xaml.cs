using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using SlideOverKit;
using PlantTaggerV1.Libraries;
using PlantTaggerV1.ViewModels;
using PlantTaggerV1.Models;

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
            NavigationPage.SetBackButtonTitle(this, "");
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
            ObservableCollection<MenuItemWithFALabel> menuItems = new ObservableCollection<MenuItemWithFALabel>();

            MenuItemWithFALabel settingsItem = new MenuItemWithFALabel();
            settingsItem.Text = "Settings";
            settingsItem.FALabel = FontAwesome.FACog;
            MenuItemWithFALabel logoutItem = new MenuItemWithFALabel();
            logoutItem.Text = "Logout";
            logoutItem.FALabel = FontAwesome.FASignOut;
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

        private void OnPlantItemTapped(ListView sender, ItemTappedEventArgs e)
        {
            sender.SelectedItem = null;
        }
    }
}
