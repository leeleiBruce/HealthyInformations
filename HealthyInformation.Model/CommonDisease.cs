//------------------------------------------------------------------------------
// <auto-generated>
//    此代码是根据模板生成的。
//
//    手动更改此文件可能会导致应用程序中发生异常行为。
//    如果重新生成代码，则将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthyInformation.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class CommonDisease
    {
        public int TransactionNumber { get; set; }
        public string SymptomName { get; set; }
        public string SymptomDetail { get; set; }
        public string Medication { get; set; }
        public string TreatmentPlan { get; set; }
        public System.DateTime InDate { get; set; }
        public string InUser { get; set; }
        public System.DateTime LastEditDate { get; set; }
        public string LastEditUser { get; set; }
    }
}
