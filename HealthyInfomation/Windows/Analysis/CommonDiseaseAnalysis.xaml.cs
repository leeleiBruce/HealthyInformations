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
using HealthyInformation.Utility;
using HealthyInformation.ClientEntity.Analysis;
using Visifire.Charts;

namespace HealthyInfomation.Windows.Analysis
{
    /// <summary>
    /// CommonDiseaseAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class CommonDiseaseAnalysis : WindowBase
    {
        AnalysisFacade facade;
        List<UP_GetCommonDiseaseAnalysis_Result> dataResult;
        public CommonDiseaseAnalysis()
        {
            InitializeComponent();
            facade = new AnalysisFacade(this);
            this.DataContext = this;
            this.Loaded += CommonDiseaseAnalysis_Loaded; ;
            this.PropertyChanged += HealthyGradeAnalysis_PropertyChanged;
        }

        private void CommonDiseaseAnalysis_Loaded(object sender, RoutedEventArgs e)
        {
            this.Year = DateTime.Now.Year;
            this.InitData();
        }

        private async void InitData()
        {
            this.dataResult = await this.facade.GetCommonDiseaseAnalysis(this.Year);
            var xList = this.dataResult.Select(d => d.SymptomName).ToList();
            var yList = this.dataResult.Select(d => d.TotalCount.ToString()).ToList();

            this.AnalysisChart.CreateChartPie("病症分布统计", xList, yList, 500, 260, dataPoint_MouseLeftButtonDown);
            this.DG_Detail.ItemsSource = null;
        }

        private void HealthyGradeAnalysis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Year))
            {
                this.InitData();
            }
        }
        private async void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string commonDiseaseName = (sender as DataPoint).Tag as string;
            var commonDisease = this.dataResult.FirstOrDefault(d => d.SymptomName == commonDiseaseName);
            var result = await facade.GetCommonDiseaseDetail(Year, commonDisease?.TransactionNumber ?? 0);
            this.DG_Detail.ItemsSource = result;
        }
    }
}
