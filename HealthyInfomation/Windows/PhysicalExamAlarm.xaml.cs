using HealthyInfomation.Facade;
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

namespace HealthyInfomation.Windows
{
    /// <summary>
    /// PhysicalExamAlarm.xaml 的交互逻辑
    /// </summary>
    public partial class PhysicalExamAlarm : WindowBase
    {
        PhysicalExamMaxFacade physicalExamMaxFacade;
        public PhysicalExamAlarm()
        {
            InitializeComponent();
            physicalExamMaxFacade = new PhysicalExamMaxFacade(this);
            InitData();
        }

        #region ViewModel
        private List<UP_GetPhysicalExamAlarmInfo_Result> physicalExamAlarmInfoList;
        public List<UP_GetPhysicalExamAlarmInfo_Result> PhysicalExamAlarmInfoList
        {
            get
            {
                return physicalExamAlarmInfoList;
            }
            set
            {
                physicalExamAlarmInfoList = value;
                RaisePropertyChanged("physicalExamAlarmInfoList");
            }
        }

        #endregion

        #region Method
        private async void InitData()
        {
            this.PhysicalExamAlarmInfoList = await this.physicalExamMaxFacade.GetPhysicalExamAlarm();
        }
        #endregion

    }
}
