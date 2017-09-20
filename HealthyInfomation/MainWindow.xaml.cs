using HealthyInfomation.Facade;
using HealthyInfomation.Resource;
using HealthyInfomation.Windows;
using HealthyInfomation.Windows.Analysis;
using HealthyInfomation.Windows.PhysicalExam;
using HealthyInfomation.Windows.UserControl;
using HealthyInformation.ClientEntity.PhysicalExam.Entity;
using HealthyInformation.FrameWork;
using HealthyInformation.FrameWork.AuthorUser;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HealthyInfomation
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : WindowBase
    {
        MedicalTreatmentFacade medicalTreatmentFacade;
        Timer timer = new Timer(1000);
        Timer timerAlarm = new Timer(60 * 1000 * 10);
        List<UP_GetMedicalTreatAlarmInfo_Result> medicalTreatAlarmList;

        public MainWindow()
        {
            InitializeComponent();
            timer.Elapsed += timer_Elapsed;
            timer.Start();
            timerAlarm.Elapsed += timerAlarm_Elasped;
            timerAlarm.Start();
            DataContext = this;
            medicalTreatmentFacade = new MedicalTreatmentFacade(this, false);
            CurrentTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
            InitData();
            marqueeAlarm.PopupDetail += MarqueeAlarm_PopupDetail;
        }

        private void MarqueeAlarm_PopupDetail()
        {
            if (medicalTreatAlarmList?.Count > 0)
            {
                new MedicalTreatmentAlarm(medicalTreatAlarmList).ShowDialog();
            }
        }

        private string currentTime;
        public string CurrentTime
        {
            get
            {
                return currentTime;
            }
            set
            {
                currentTime = value;
                RaisePropertyChanged("CurrentTime");
            }
        }

        public ICommand ToolBarCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    this.ShowWindow(obj);
                });
            }
        }

        private void ShowWindow(object parameter)
        {
            string param = parameter as string;
            if (param == "disease")
            {
                new CommonDisease().ShowDialog();
            }
            else if (param == "doctor")
            {
                new AviationMedicine().ShowDialog();
            }
            else if (param == "sanatorium")
            {
                new Sanatorium().ShowDialog();
            }
            else if (param == "pilot")
            {
                new AircrewManage().ShowDialog();
            }
            else if (param == "physicalexammax")
            {
                new PhysicalExamMain().ShowDialog();
            }
            else if (param == "physicalexammin")
            {
                new PhysicalExamMin().ShowDialog();
            }
            else if (param == "recuperation")
            {
                new RecuperationPlan().ShowDialog();
            }
            else if (param == "alarm")
            {
                new PhysicalExamAlarm().ShowDialog();
            }
            else if (param == "userpwd")
            {
                new ModifyPassWord().ShowDialog();
            }
            else if (param == "Analysis")
            {
                new AnalysisMain().ShowDialog();
            }
            else if (param == "flyerType")
            {
                new FlyerTypeManage().ShowDialog();
            }
        }

        private  void InitData()
        {
            App.Current.Dispatcher.Invoke((Action)(async () =>
            {
                medicalTreatAlarmList = await this.medicalTreatmentFacade.GetMedicalTreatmentByAlarm();
                if (medicalTreatAlarmList?.Count > 0)
                {
                    this.marqueeAlarm.MarqueeContent = string.Format("共有{0}名人员地观日期将至，请提前处理！", medicalTreatAlarmList.Count);
                }
            }));

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.ShowConfirm(MainResource.Msg_ExitConfirm) == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown(0);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.CurrentTime = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
        }

        private void timerAlarm_Elasped(object sender, ElapsedEventArgs e)
        {
            InitData();
        }
    }
}
