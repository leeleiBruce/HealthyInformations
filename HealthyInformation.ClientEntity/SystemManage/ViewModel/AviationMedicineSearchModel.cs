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
    public class AviationMedicineSearchModel : ModelBase
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

        private ObservableCollection<AviationMedicineEntity> aviationMedicineList;
        public ObservableCollection<AviationMedicineEntity> AviationMedicineList
        {
            get
            {
                return aviationMedicineList;
            }
            set
            {
                aviationMedicineList = value;
                RaisePropertyChanged("AviationMedicineList");
            }
        }

        private AviationMedicineEntity selectedAviationMedicine;
        public AviationMedicineEntity SelectedAviationMedicine
        {
            get
            {
                return selectedAviationMedicine;
            }
            set
            {
                selectedAviationMedicine = value;
                RaisePropertyChanged("SelectedAviationMedicine");
            }
        }
    }
}
