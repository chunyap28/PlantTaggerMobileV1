using System;
using System.Collections.Generic;
using SlideOverKit;
using Xamarin.Forms;

namespace PlantTaggerV1.Views
{
    public partial class RightSideMenu : SlideMenuView
    {
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

        private void OnItemSelected(object sender, EventArgs e)
        {
            
            
        }
    }
}
