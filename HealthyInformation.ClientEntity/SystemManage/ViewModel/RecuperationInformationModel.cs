using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.ViewModel
{
    public class RecuperationInformationModel : ModelBase
    {
        private int sanatoriumID;
        [Range(1, 1000, ErrorMessage = "疗养院无效！")]
        public int SanatoriumID
        {
            get
            {
                return sanatoriumID;
            }
            set
            {
                sanatoriumID = value;
                RaisePropertyChanged("SanatoriumID");
            }
        }

        private string detailAddress;
        public string DetailAddress
        {
            get
            {
                return detailAddress;
            }
            set
            {
                detailAddress = value;
                RaisePropertyChanged("DetailAddress");
            }
        }

        private string recommendTravelMode;
        public string RecommendTravelMode
        {
            get
            {
                return recommendTravelMode;
            }
            set
            {
                recommendTravelMode = value;
                RaisePropertyChanged("RecommendTravelMode");
            }
        }

        private string contactPhone;
        public string ContactPhone
        {
            get
            {
                return contactPhone;
            }
            set
            {
                contactPhone = value;
                RaisePropertyChanged("ContactPhone");
            }
        }

        private DateTime? hospitalizationDatePlan;
        [Required(ErrorMessage = "计划入院日期不能为空！")]
        public DateTime? HospitalizationDatePlan
        {
            get
            {
                return hospitalizationDatePlan;
            }
            set
            {
                hospitalizationDatePlan = value;
                RaisePropertyChanged("HospitalizationDatePlan");
            }
        }

        private DateTime? dischargeDatePlan;
        [Required(ErrorMessage = "计划出院日期不能为空！")]
        public DateTime? DischargeDatePlan
        {
            get
            {
                return dischargeDatePlan;
            }
            set
            {
                dischargeDatePlan = value;
                RaisePropertyChanged("DischargeDatePlan");
            }
        }

        private int leaderID;
        public int LeaderID
        {
            get
            {
                return leaderID;
            }
            set
            {
                leaderID = value;
                RaisePropertyChanged("LeaderID");
            }
        }

        private string leaderContactTel;
        public string LeaderContactTel
        {
            get
            {
                return leaderContactTel;
            }
            set
            {
                leaderContactTel = value;
                RaisePropertyChanged("LeaderContactTel");
            }
        }

        private int aviationMedicineID;
        public int AviationMedicineID
        {
            get
            {
                return aviationMedicineID;
            }
            set
            {
                aviationMedicineID = value;
                RaisePropertyChanged("AviationMedicineID");
            }
        }

        private AircrewEntity aircrewEntity;
        public AircrewEntity AircrewEntity
        {
            get
            {
                return aircrewEntity;
            }
            set
            {
                aircrewEntity = value;
                RaisePropertyChanged("AircrewEntity");
            }
        }

        private List<AviationMedicineEntity> aviationMedicineList;
        public List<AviationMedicineEntity> AviationMedicineList
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

        private List<AircrewEntity> aircrewEntityList;
        public List<AircrewEntity> AircrewEntityList
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
