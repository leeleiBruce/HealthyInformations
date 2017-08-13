using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyInformation.ClientEntity.Analysis
{
    public class UP_GetCommonDiseaseAnalysis_Result
    {
        public int TransactionNumber { get; set; }
        public string SymptomName { get; set; }
        public Nullable<int> TotalCount { get; set; }
    }
}
