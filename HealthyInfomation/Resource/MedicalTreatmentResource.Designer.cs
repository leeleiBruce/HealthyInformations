﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.17929
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace HealthyInfomation.Resource {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class MedicalTreatmentResource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal MedicalTreatmentResource() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("HealthyInfomation.Resource.MedicalTreatmentResource", typeof(MedicalTreatmentResource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   查找类似 否 的本地化字符串。
        /// </summary>
        public static string Chk_No {
            get {
                return ResourceManager.GetString("Chk_No", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 是 的本地化字符串。
        /// </summary>
        public static string Chk_Yes {
            get {
                return ResourceManager.GetString("Chk_Yes", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 检查情况： 的本地化字符串。
        /// </summary>
        public static string Lab_CheckSituation {
            get {
                return ResourceManager.GetString("Lab_CheckSituation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 结论： 的本地化字符串。
        /// </summary>
        public static string Lab_Conclusion {
            get {
                return ResourceManager.GetString("Lab_Conclusion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 诊断： 的本地化字符串。
        /// </summary>
        public static string Lab_Diagnosis {
            get {
                return ResourceManager.GetString("Lab_Diagnosis", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 出院日期： 的本地化字符串。
        /// </summary>
        public static string Lab_DischargeDate {
            get {
                return ResourceManager.GetString("Lab_DischargeDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 入院日期： 的本地化字符串。
        /// </summary>
        public static string Lab_HospitalizationDate {
            get {
                return ResourceManager.GetString("Lab_HospitalizationDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 送医地点： 的本地化字符串。
        /// </summary>
        public static string Lab_HospitalLocation {
            get {
                return ResourceManager.GetString("Lab_HospitalLocation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 送医原因： 的本地化字符串。
        /// </summary>
        public static string Lab_HospitalReason {
            get {
                return ResourceManager.GetString("Lab_HospitalReason", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 地观（是/否）： 的本地化字符串。
        /// </summary>
        public static string Lab_NeedObservation {
            get {
                return ResourceManager.GetString("Lab_NeedObservation", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 地观时间： 的本地化字符串。
        /// </summary>
        public static string Lab_ObservationStartDate {
            get {
                return ResourceManager.GetString("Lab_ObservationStartDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 日期： 的本地化字符串。
        /// </summary>
        public static string Lab_RecordDate {
            get {
                return ResourceManager.GetString("Lab_RecordDate", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 地观结束时间不能为空！ 的本地化字符串。
        /// </summary>
        public static string Msg_EndDateEmpty {
            get {
                return ResourceManager.GetString("Msg_EndDateEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 地观开始时间不能为空！ 的本地化字符串。
        /// </summary>
        public static string Msg_StartDateEmpty {
            get {
                return ResourceManager.GetString("Msg_StartDateEmpty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 地观开始时间不能大于地观结束时间！ 的本地化字符串。
        /// </summary>
        public static string Msg_StartDateLaterThanEnd {
            get {
                return ResourceManager.GetString("Msg_StartDateLaterThanEnd", resourceCulture);
            }
        }
    }
}
