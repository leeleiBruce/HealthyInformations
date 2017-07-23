using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class ENTSectionModel : ModelBase
    {
        private int aircrewID;
        public int AircrewID
        {
            get
            {
                return aircrewID;
            }
            set
            {
                aircrewID = value;
                RaisePropertyChanged("AircrewID");
            }
        }

        private string medicalHistory;
        public string MedicalHistory
        {
            get
            {
                return medicalHistory;
            }
            set
            {
                medicalHistory = value;
                RaisePropertyChanged("MedicalHistory");
            }
        }

        private string checkOut;
        [Required(ErrorMessage = "检查所见不能为空！")]
        public string CheckOut
        {
            get
            {
                return checkOut;
            }
            set
            {
                checkOut = value;
                RaisePropertyChanged("CheckOut");
            }
        }

        private string earLeft;
        public string EarLeft
        {
            get
            {
                return earLeft;
            }
            set
            {
                earLeft = value;
                RaisePropertyChanged("EarLeft");
            }
        }

        private string earRight;
        public string EarRight
        {
            get
            {
                return earRight;
            }
            set
            {
                earRight = value;
                RaisePropertyChanged("EarRight");
            }
        }

        private string earWhisperLeft;
        public string EarWhisperLeft
        {
            get
            {
                return earWhisperLeft;
            }
            set
            {
                earWhisperLeft = value;
                RaisePropertyChanged("EarWhisperLeft");
            }
        }

        private string earWhisperRight;
        public string EarWhisperRight
        {
            get
            {
                return earWhisperRight;
            }
            set
            {
                earWhisperRight = value;
                RaisePropertyChanged("EarWhisperRight");
            }
        }

        private string nose;
        public string Nose
        {
            get
            {
                return nose;
            }
            set
            {
                nose = value;
                RaisePropertyChanged("Nose");
            }
        }

        private string smell;
        public string Smell
        {
            get
            {
                return smell;
            }
            set
            {
                smell = value;
                RaisePropertyChanged("Smell");
            }
        }

        private string ventilation;
        public string Ventilation
        {
            get
            {
                return ventilation;
            }
            set
            {
                ventilation = value;
                RaisePropertyChanged("Ventilation");
            }
        }

        private string throat;
        public string Throat
        {
            get
            {
                return throat;
            }
            set
            {
                throat = value;
                RaisePropertyChanged("Throat");
            }
        }

        private string earCompressor;
        public string EarCompressor
        {
            get
            {
                return earCompressor;
            }
            set
            {
                earCompressor = value;
                RaisePropertyChanged("EarCompressor");
            }
        }

        private string vestibularFunction;
        public string VestibularFunction
        {
            get
            {
                return vestibularFunction;
            }
            set
            {
                vestibularFunction = value;
                RaisePropertyChanged("VestibularFunction");
            }
        }

        private string diagnosisConclusion;
        [Required(ErrorMessage = "诊断结论不能为空！")]
        public string DiagnosisConclusion
        {
            get
            {
                return diagnosisConclusion;
            }
            set
            {
                diagnosisConclusion = value;
                RaisePropertyChanged("DiagnosisConclusion");
            }
        }

        private string suggestion;
        public string Suggestion
        {
            get
            {
                return suggestion;
            }
            set
            {
                suggestion = value;
                RaisePropertyChanged("Suggestion");
            }
        }

        private DateTime? recordDate;
        [Required(ErrorMessage="日期不能为空！")]
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

        private int? aviationMedicineID;
        [Required(ErrorMessage = "所选医师无效！")]
        [Range(1, 1000, ErrorMessage = "所选医师无效！")]
        public int? AviationMedicineID
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
    }
}
