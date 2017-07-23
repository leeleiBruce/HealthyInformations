using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.ViewModel
{
    public class PhthalmologyModel : ModelBase
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

        private string visionLeft;
        [Required(ErrorMessage = "不能为空")]
        public string VisionLeft
        {
            get
            {
                return visionLeft;
            }
            set
            {
                visionLeft = value;
                RaisePropertyChanged("VisionLeft");
            }
        }

        private string visionRight;
        [Required(ErrorMessage = "不能为空")]
        public string VisionRight
        {
            get
            {
                return visionRight;
            }
            set
            {
                visionRight = value;
                RaisePropertyChanged("VisionRight");
            }
        }

        private string nearVisionLeft;
        [Required(ErrorMessage = "不能为空")]
        public string NearVisionLeft
        {
            get
            {
                return nearVisionLeft;
            }
            set
            {
                nearVisionLeft = value;
                RaisePropertyChanged("NearVisionLeft");
            }
        }

        private string nearVisionRight;
        [Required(ErrorMessage = "不能为空")]
        public string NearVisionRight
        {
            get
            {
                return nearVisionRight;
            }
            set
            {
                nearVisionRight = value;
                RaisePropertyChanged("NearVisionRight");
            }
        }

        private string distantVisionLeft;
        [Required(ErrorMessage = "不能为空")]
        public string DistantVisionLeft
        {
            get
            {
                return distantVisionLeft;
            }
            set
            {
                distantVisionLeft = value;
                RaisePropertyChanged("DistantVisionLeft");
            }
        }

        private string distantVisionRight;
        [Required(ErrorMessage = "不能为空")]
        public string DistantVisionRight
        {
            get
            {
                return distantVisionRight;
            }
            set
            {
                distantVisionRight = value;
                RaisePropertyChanged("DistantVisionRight");
            }
        }

        private string curveLightLeft;
        public string CurveLightLeft
        {
            get
            {
                return curveLightLeft;
            }
            set
            {
                curveLightLeft = value;
                RaisePropertyChanged("CurveLightLeft");
            }
        }

        private string curveLightRight;
        public string CurveLightRight
        {
            get
            {
                return curveLightRight;
            }
            set
            {
                curveLightRight = value;
                RaisePropertyChanged("CurveLightRight");
            }
        }

        private string heterophoria;
        public string Heterophoria
        {
            get
            {
                return heterophoria;
            }
            set
            {
                heterophoria = value;
                RaisePropertyChanged("Heterophoria");
            }
        }

        private string colorVision;
        [Required(ErrorMessage = "不能为空")]
        public string ColorVision
        {
            get
            {
                return colorVision;
            }
            set
            {
                colorVision = value;
                RaisePropertyChanged("ColorVision");
            }
        }

        private string rangeRecognition;
        [Required(ErrorMessage = "不能为空")]
        public string RangeRecognition
        {
            get
            {
                return rangeRecognition;
            }
            set
            {
                rangeRecognition = value;
                RaisePropertyChanged("RangeRecognition");
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

        private string eyelid;
        [Required(ErrorMessage = "不能为空")]
        public string Eyelid
        {
            get
            {
                return eyelid;
            }
            set
            {
                eyelid = value;
                RaisePropertyChanged("Eyelid");
            }
        }

        private string eyeball;
        [Required(ErrorMessage = "不能为空")]
        public string Eyeball
        {
            get
            {
                return eyeball;
            }
            set
            {
                eyeball = value;
                RaisePropertyChanged("Eyeball");
            }
        }

        private string convolutedStroma;
        public string ConvolutedStroma
        {
            get
            {
                return convolutedStroma;
            }
            set
            {
                convolutedStroma = value;
                RaisePropertyChanged("ConvolutedStroma");
            }
        }

        private string eyeBellow;
        public string EyeBellow
        {
            get
            {
                return eyeBellow;
            }
            set
            {
                eyeBellow = value;
                RaisePropertyChanged("EyeBellow");
            }
        }

        private string nightVision;
        [Required(ErrorMessage = "不能为空")]
        public string NightVision
        {
            get
            {
                return nightVision;
            }
            set
            {
                nightVision = value;
                RaisePropertyChanged("NightVision");
            }
        }

        private string diagnosisConclusion;
        [Required(ErrorMessage = "不能为空")]
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

        private int aviationMedicineID;
        [Range(1, 1000, ErrorMessage = "医师无效")]
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
    }
}
