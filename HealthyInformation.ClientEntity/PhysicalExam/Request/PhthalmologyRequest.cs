using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.PhysicalExam.Request
{
    public class PhthalmologyRequest : BaseRequest
    {
        public int AircrewID { get; set; }
        public string VisionLeft { get; set; }
        public string VisionRight { get; set; }
        public string NearVisionLeft { get; set; }
        public string NearVisionRight { get; set; }
        public string DistantVisionLeft { get; set; }
        public string DistantVisionRight { get; set; }
        public string CurveLightLeft { get; set; }
        public string CurveLightRight { get; set; }
        public string Heterophoria { get; set; }
        public string ColorVision { get; set; }
        public string RangeRecognition { get; set; }
        public string MedicalHistory { get; set; }
        public string Eyelid { get; set; }
        public string Eyeball { get; set; }
        public string ConvolutedStroma { get; set; }
        public string EyeBellow { get; set; }
        public string NightVision { get; set; }
        public string DiagnosisConclusion { get; set; }
        public string Suggestion { get; set; }
        public int AviationMedicineID { get; set; }
    }
}
