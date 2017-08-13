using HealthyInfomation.Facade;
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
using Visifire.Charts;
using HealthyInformation.Utility;

namespace HealthyInfomation.Windows.UserControl
{
    /// <summary>
    /// RecuperationInformationAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class RecuperationInformationAnalysis : WindowBase
    {
        RecuperationInformationFacade facade;
        public RecuperationInformationAnalysis()
        {
            InitializeComponent();
            facade = new RecuperationInformationFacade(this);
            InitData();
        }

        private async void InitData()
        {
            var result = await facade.GetRecuperationAnalysisCountResult();
            this.AnalysisChart.CreateChartPie(string.Concat(DateTime.Now.Year, "年度疗养人员统计"), new List<string> { "未参加疗养人员", "参加疗养人员" }
            , new List<string> { (result.TotalCont - result.AppendCount).ToString(), result.AppendCount.ToString() }, 600, 340, dataPoint_MouseLeftButtonDown);
        }

        private async void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as DataPoint).Tag.ToString() == "参加疗养人员")
            {
                var result = await facade.GetRecuperationAnalysisResult();
                this.DG_Detail.ItemsSource = result;
            }
        }
    }
}
