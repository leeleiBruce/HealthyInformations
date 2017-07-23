using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.SystemManage.ViewModel
{
    public class AviationMedicineModel : ModelBase
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

        private string graduationSchool;
        [Required(ErrorMessage = "毕业院校不能为空！")]
        public string GraduationSchool
        {
            get
            {
                return graduationSchool;
            }
            set
            {
                graduationSchool = value;
                RaisePropertyChanged("GraduationSchool");
            }
        }

        private string professional;
        [Required(ErrorMessage = "专业不能为空！")]
        public string Professional
        {
            get
            {
                return professional;
            }
            set
            {
                professional = value;
                RaisePropertyChanged("Professional");
            }
        }

        private DateTime? workDate;
        [Required(ErrorMessage="从业日期不能为空！")]
        public DateTime? WorkDate
        {
            get
            {
                return workDate;
            }
            set
            {
                workDate = value;
                RaisePropertyChanged("WorkDate");
            }
        }

        private string contactTel;
        [Required(ErrorMessage = "联系电话不能为空！")]
        public string ContactTel
        {
            get
            {
                return contactTel;
            }
            set
            {
                contactTel = value;
                RaisePropertyChanged("ContactTel");
            }
        }

        private string personQualification;
        [Required(ErrorMessage = "个人资质不能为空！")]
        public string PersonQualification
        {
            get
            {
                return personQualification;
            }
            set
            {
                personQualification = value;
                RaisePropertyChanged("PersonQualification");
            }
        }
    }
}
