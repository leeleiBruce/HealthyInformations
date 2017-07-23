using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.ViewModel
{
    public class AircrewModel : ModelBase
    {
        private string name;

        [Required(ErrorMessage = "姓名不能为空！")]
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

        private DateTime? birthDay;
        [Required(ErrorMessage = "出生日期不能为空！")]
        public DateTime? BirthDay
        {
            get
            {
                return birthDay;
            }
            set
            {
                birthDay = value;
                RaisePropertyChanged("BirthDay");
            }
        }

        private string sex;
        public string Sex
        {
            get
            {
                return sex;
            }
            set
            {
                sex = value;
                RaisePropertyChanged("Sex");
            }
        }

        private string nation;
        [Required(ErrorMessage = "民族不能为空！")]
        public string Nation
        {
            get
            {
                return nation;
            }
            set
            {
                nation = value;
            }
        }

        public string Photo { get; set; }

        private string degree;
        [Required(ErrorMessage = "文化程度不能为空！")]
        public string Degree
        {
            get
            {
                return degree;
            }
            set
            {
                degree = value;
                RaisePropertyChanged("Degree");
            }
        }

        private DateTime? enlistmentTime;
        [Required(ErrorMessage = "入伍时间不能为空！")]
        public DateTime? EnlistmentTime
        {
            get
            {
                return enlistmentTime;
            }
            set
            {
                enlistmentTime = value;
                RaisePropertyChanged("EnlistmentTime");
            }
        }

        private DateTime? partyTime;
        [Required(ErrorMessage = "入党时间不能为空！")]
        public DateTime? PartyTime
        {
            get
            {
                return partyTime;
            }
            set
            {
                partyTime = value;
                RaisePropertyChanged("PartyTime");
            }
        }

        private string nativePlace;
        [Required(ErrorMessage = "籍贯不能为空！")]
        public string NativePlace
        {
            get
            {
                return nativePlace;
            }
            set
            {
                nativePlace = value;
                RaisePropertyChanged("NativePlace");
            }
        }

        private string troopsType;
        [Required(ErrorMessage = "部别不能为空！")]
        public string TroopsType
        {
            get
            {
                return troopsType;
            }
            set
            {
                troopsType = value;
                RaisePropertyChanged("TroopsType");
            }
        }

        private string troopsTel;
        [Required(ErrorMessage = "电话不能为空！")]
        public string TroopsTel
        {
            get
            {
                return troopsTel;
            }
            set
            {
                troopsTel = value;
                RaisePropertyChanged("TroopsTel");
            }
        }

        private string jobTitle;
        [Required(ErrorMessage = "职别不能为空！")]
        public string JobTitle
        {
            get
            {
                return jobTitle;
            }
            set
            {
                jobTitle = value;
                RaisePropertyChanged("JobTitle");
            }
        }

        private string militaryRank;
        [Required(ErrorMessage = "军衔不能为空！")]
        public string MilitaryRank
        {
            get
            {
                return militaryRank;
            }
            set
            {
                militaryRank = value;
                RaisePropertyChanged("MilitaryRank");
            }
        }

        private string admissionJuniorCollege;
        [Required(ErrorMessage = "基础学院不能为空！")]
        public string AdmissionJuniorCollege
        {
            get
            {
                return admissionJuniorCollege;
            }
            set
            {
                admissionJuniorCollege = value;
                RaisePropertyChanged("AdmissionJuniorCollege");
            }
        }

        private string admissionCollege;
        [Required(ErrorMessage = "飞行学院不能为空！")]
        public string AdmissionCollege
        {
            get
            {
                return admissionCollege;
            }
            set
            {
                admissionCollege = value;
                RaisePropertyChanged("AdmissionCollege");
            }
        }

        private DateTime? graduationJuniorDate;
        [Required(ErrorMessage = "毕业时间不能为空！")]
        public DateTime? GraduationJuniorDate
        {
            get
            {
                return graduationJuniorDate;
            }
            set
            {
                graduationJuniorDate = value;
                RaisePropertyChanged("GraduationJuniorDate");
            }
        }

        private DateTime? graduationDate;
        [Required(ErrorMessage = "毕业时间不能为空！")]
        public DateTime? GraduationDate
        {
            get
            {
                return graduationDate;
            }
            set
            {
                graduationDate = value;
                RaisePropertyChanged("GraduationDate");
            }
        }

        private DateTime? pilotPlaneDate;
        [Required(ErrorMessage = "开飞日期不能为空！")]
        public DateTime? PilotPlaneDate
        {
            get
            {
                return pilotPlaneDate;
            }
            set
            {
                pilotPlaneDate = value;
                RaisePropertyChanged("PilotPlaneDate");
            }
        }

        private string terminateContractDetail;
        [MaxLength(4000, ErrorMessage = "长度不能超过4000！")]
        public string TerminateContractDetail
        {
            get
            {
                return terminateContractDetail;
            }
            set
            {
                terminateContractDetail = value;
                RaisePropertyChanged("TerminateContractDetail");
            }
        }

        public DateTime InDate { get; set; }

        public DateTime LastEditDate { get; set; }

        public string InUser { get; set; }

        public string LastEditUser { get; set; }
    }
}
