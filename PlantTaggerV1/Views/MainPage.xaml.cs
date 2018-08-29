using System;
using PlantTaggerV1.ViewModels;
using Xamarin.Forms;
using SlideOverKit;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlantTaggerV1.Views
{
    public partial class MainPage : ContentPage, IMenuContainerPage
    {
        private RightSideMenu _rightSideMenu = new RightSideMenu();

        public MainPage()
        {
            InitializeComponent();
            SlideMenu = _rightSideMenu;
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

        /*
        protected override async void OnAppearing()
        {
            var content = this.Content;
            this.Content = null;
            this.Content = content;

            var vm = BindingContext as MainPageModel;
        }*/

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            _rightSideMenu.BindingContext = BindingContext;
        }

        private void OnSideMenuRequested(object sender, EventArgs e){
            //System.Diagnostics.Debug.WriteLine("Side Menu Requested");
            Filter();
        }

        private void Filter()
        {
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
