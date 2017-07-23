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
    public class SanatoriumSearchModel : ModelBase
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        public int TotalCount { get; set; }

        private ObservableCollection<SanatoriumEntity> sanatoriumEntityList;
        public ObservableCollection<SanatoriumEntity> SanatoriumEntityList
        {
            get
            {
                return sanatoriumEntityList;
            }
            set
            {
                sanatoriumEntityList = value;
                RaisePropertyChanged("SanatoriumEntityList");
            }
        }

        private SanatoriumEntity selectedSanatorium;
        public SanatoriumEntity SelectedSanatorium
        {
            get
            {
                return selectedSanatorium;
            }
            set
            {
                selectedSanatorium = value;
                RaisePropertyChanged("SelectedSanatorium");
            }
        }
    }
}
