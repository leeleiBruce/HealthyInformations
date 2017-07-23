using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.ViewModel
{
    public class AircrewMemberModel : ModelBase
    {
        private ObservableCollection<AircrewEntity> selectedAircrewEntityList;
        public ObservableCollection<AircrewEntity> SelectedAircrewEntityList
        {
            get
            {
                return selectedAircrewEntityList;
            }
            set
            {
                selectedAircrewEntityList = value;
                RaisePropertyChanged("SelectedAircrewEntityList");
            }
        }

        private ObservableCollection<AircrewEntity> aircrewEntityList;
        public ObservableCollection<AircrewEntity> AircrewEntityList
        {
            get
            {
                return aircrewEntityList;
            }
            set
            {
                aircrewEntityList = value;
                RaisePropertyChanged("AircrewEntityList");
            }
        }
    }
}
