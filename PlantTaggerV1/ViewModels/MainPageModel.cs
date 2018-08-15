using System;
using PlantTaggerV1.ViewModels.Base;

namespace PlantTaggerV1.ViewModels
{
    public class MainPageModel : ViewModelBase
    {
        private string _gardenName;
        private int _plantCount = 0;

        public MainPageModel()
        {
            this._gardenName = "My Garden";
        }

        public string GardenName
        {
            get
            {
                return _gardenName;
            }
            set
            {
                _gardenName = value;
                RaisePropertyChanged(() => GardenName);
            }
        }

        public int PlantCount
        {
            get
            {
                return _plantCount;
            }
            set
            {
                _plantCount = value;
                RaisePropertyChanged(() => PlantCount);
            }
        }
    }
}
