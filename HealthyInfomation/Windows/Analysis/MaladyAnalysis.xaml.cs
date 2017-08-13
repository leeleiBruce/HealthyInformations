using HealthyInfomation.Facade;
using HealthyInformation.ClientEntity.Analysis;
using HealthyInformation.FrameWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using HealthyInformation.Utility;
using Visifire.Charts;

namespace HealthyInfomation.Windows.Analysis
{
    /// <summary>
    /// MaladyAnalysis.xaml 的交互逻辑
    /// </summary>
    public partial class MaladyAnalysis : WindowBase
    {
        AnalysisFacade facade;
        List<UP_GetCommonDiseaseCountAnalysis_Result> dataResult;
        public MaladyAnalysis()
        {
            InitializeComponent();
            facade = new AnalysisFacade(this);
            this.DataContext = this;
            this.Loaded += MaladyAnalysis_Loaded;
            this.PropertyChanged += MaladyAnalysis_PropertyChanged;
        }

        private void MaladyAnalysis_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Year))
            {
                this.InitData();
            }
        }

        private void MaladyAnalysis_Loaded(object sender, RoutedEventArgs e)
        {
            this.Year = DateTime.Now.Year;
            this.InitData();
        }

        private async void InitData()
        {
            this.dataResult = await this.facade.GetCommonDiseaseCountAnalysis(this.Year);
            var xList = this.dataResult.Select(d => d.SymptomName).ToList();
            var yList = this.dataResult.Select(d => d.TotalCount.GetValueOrDefault().ToString()).ToList();

            this.AnalysisChart.CreateChartPie("常见病统计分析", xList, yList, 500, 260, dataPoint_MouseLeftButtonDown);
            this.DG_Detail.ItemsSource = null;
        }

        private async void dataPoint_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string commonDiseaseName = (sender as DataPoint).Tag as string;
            var commonDisease = this.dataResult.FirstOrDefault(d => d.SymptomName == commonDiseaseName);
            if (commonDisease?.TransactionNumber > 0)
            {
                var result = await facade.GetCommonDiseaseCountDetail(Year, commonDisease?.TransactionNumber ?? 0);
                this.DG_Detail.ItemsSource = result;
            }
        }
    }
}
