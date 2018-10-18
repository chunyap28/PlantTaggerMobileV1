using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Threading.Tasks;
using PlantTaggerV1.ViewModels;

namespace PlantTaggerV1.Views
{
    public partial class PlantDetailPage : ContentPage
    {
        public PlantDetailPage()
        {
            InitializeComponent();
        }

        private async Task OnOptionRequested(object sender, EventArgs e)
        {
            String selection = await DisplayActionSheet("Option", "Cancel", null, new string[] { "Delete" });
            if( selection.Equals("Delete") ){
                ((PlantDetailPageModel)BindingContext)?.DeletePlantCommand.Execute(sender);
            }
        }
    }
}
