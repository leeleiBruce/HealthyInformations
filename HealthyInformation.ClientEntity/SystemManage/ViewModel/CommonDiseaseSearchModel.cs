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
    public class CommonDiseaseSearchModel : ModelBase
    {
        private string diseaseName;
        public string DiseaseName
        {
            get
            {
                return diseaseName;
            }
            set
            {
                diseaseName = value;
                RaisePropertyChanged("DiseaseName");
            }
        }

        private int totalCount;
        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
                RaisePropertyChanged("TotalCount");
            }
        }

        private ObservableCollection<CommonDiseaseEntity> commonDiseaseList;
        public ObservableCollection<CommonDiseaseEntity> CommonDiseaseList
        {
            get
            {
                return commonDiseaseList;
            }
            set
            {
                commonDiseaseList = value;
                RaisePropertyChanged("CommonDiseaseList");
            }
        }

        private CommonDiseaseEntity selectedCommonDisease;
        public CommonDiseaseEntity SelectedCommonDisease
        {
            get
            {
                return selectedCommonDisease;
            }
            set
            {
                selectedCommonDisease = value;
                RaisePropertyChanged("SelectedCommonDisease");
            }
        }
    }
}
