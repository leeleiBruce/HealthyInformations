using HealthyInfomation.Windows.UserControl;
using HealthyInformation.FrameWork;
using System.Windows.Input;

namespace HealthyInfomation.Windows.Analysis
{
    /// <summary>
    /// AnalysisMain.xaml 的交互逻辑
    /// </summary>
    public partial class AnalysisMain : WindowBase
    {
        public AnalysisMain()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public ICommand OpenCommand
        {
            get
            {
                return CommandFactory.CreateCommand((obj) =>
                {
                    var param = obj as string;
                    if (param == "Recuperation")
                    {
                        new RecuperationInformationAnalysis().ShowDialog();
                    }
                    else if (param == "CommonDisease")
                    {
                        new CommonDiseaseAnalysis().ShowDialog();
                    }
                    else if (param == "HealthyLevel")
                    {
                        new HealthyLevelAnalysis().ShowDialog();
                    }
                    else if (param == "Malady")
                    {
                        new MaladyAnalysis().ShowDialog();
                    }
                });
            }
        }
    }
}
