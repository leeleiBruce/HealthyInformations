using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.Analysis
{
    public class UP_GetCommonDiseaseCountDetail_Result
    {
        public int TransactionNumber { get; set; }
        public string SymptomName { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string JobTitle { get; set; }
        public string TroopsType { get; set; }
        public string Conclusion { get; set; }
    }
}
