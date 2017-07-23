using HealthyInformation.ClientEntity.SystemManage.Entity;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class MedicalIdentificationModel : ModelBase
    {
        public MedicalIdentificationModel()
        { }

        #region Property

        private string content;
        [Required(ErrorMessage = "内容不能为空！")]
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                RaisePropertyChanged("Content");
            }
        }

        private int aviationMedicineID;
        [Range(1,10000, ErrorMessage = "航空军医无效！")]
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

        private DateTime? recordDate;
        [Required(ErrorMessage = "登记日期不能为空！")]
        public DateTime? RecordDate
        {
            get
            {
                return recordDate;
            }
            set
            {
                recordDate = value;
                RaisePropertyChanged("RecordDate");
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

        #endregion
    }
}
