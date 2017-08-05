using HealthyInformation.ClientEntity.PhysicalExam.Entity;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HealthyInfomation.Windows.PhysicalExam
{
    /// <summary>
    /// MedicalTreatmentAlarm.xaml 的交互逻辑
    /// </summary>
    public partial class MedicalTreatmentAlarm : WindowBase
    {
        public MedicalTreatmentAlarm()
        {
            InitializeComponent();
        }

        public MedicalTreatmentAlarm(List<UP_GetMedicalTreatAlarmInfo_Result> sourceList)
            : this()
        {
            DG_Alarm.ItemsSource = sourceList;
        }
    }
}
